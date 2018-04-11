using DashboardApi.Data;
using PasswordPolicy.Helpers;
using PasswordPolicy.Models.MMPAY;
using PasswordPolicy.Models.MMPAY.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Diagnostics;
using System.Configuration;

namespace PasswordPolicy.Data
{
    public class ApplicationRepository
    {

        // Retrieve if password is expired
        public IList<UserPwdHistoryDto> RetrievePasswordHistory(int userId)
        {
            using (var ctx = new MmpayDbContext())
            {
                var result = ctx.CPSUserPwdLog
                    .Where(u => u.UserId == userId)
                    .OrderByDescending(u => u.PwdModifyDate)
                   .Select(u => new UserPwdHistoryDto
                   {
                       UserId = u.UserId,
                       PwdModifyDate = u.PwdModifyDate,

                   }).Take(5).ToList();


                return result;
            }

        }


        public bool VerifyPasswordExpiration(IList<UserPwdHistoryDto> result)
        {

            string parameter = string.Empty;
            int days = 0;

            days = Convert.ToInt16(ConfigurationManager.AppSettings["DaysExpired"]);

            bool isValisPwd = Tools.ValidatePasswordExpiration(result, days);

            if (!isValisPwd)
            {
                // password is expired 
                return true;
            }

            return false;
        }

        public bool BlockUser(PasswordPolicy passwordPolicy)
        {
            var user = new CPSUsers() { UserID = passwordPolicy.UserId, Blocked = true };

            using (var ctx = new MmpayDbContext())
            {
                ctx.CPSUsers.Attach(user);
                ctx.Entry(user).Property(x => x.Blocked).IsModified = true;
                ctx.SaveChanges();

                return ctx.SaveChanges() == 1 ? false : true;
            }

        }

        /// <summary>
        /// Log Events or Exception.
        /// </summary>
        /// <param name="info"></param>
        /// <param name="responseMsg"></param>
        /// <param name="httpCode"></param>
        /// <param name="merchantNum"></param>
        /// <param name="requestParams"></param>
        public void LogApiEvents(string info, string responseMsg, HttpStatusCode httpCode, string userId = "0", string requestParams = "{}")
        {
            try
            {
                var eventLog = new PasswordAPILog
                {
                    Merchant_Number = userId,
                    XML_Request = requestParams,
                    XML_Response = responseMsg,
                    Additional_Info = info,
                    Process_Date = DateTime.Now,
                    Response_Code = (int)httpCode,
                };

                using (var ctx = new MmpayDbContext())
                {
                    ctx.ApiLog.Add(eventLog);
                    ctx.SaveChanges();
                }
            }
            catch (Exception e)
            {
                using (System.Diagnostics.EventLog eventLog = new System.Diagnostics.EventLog("Application"))
                {
                    eventLog.Source = "Application";
                    eventLog.WriteEntry(Tools.ReturnExMsg(e, ""), EventLogEntryType.Error, 500, 6);
                }
            }

        }

    }
}
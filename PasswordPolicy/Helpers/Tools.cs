using Newtonsoft.Json;
using PasswordPolicy.Models.MMPAY.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace PasswordPolicy.Helpers
{
    public static class Tools
    {


        #region CONVERT TO JSON

        /// <summary>
        /// Receive a List values type of T. Return a Json.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="values"></param>
        /// <returns></returns>
        public static string ConvertResponseToJson<T>(T values)
        {

            var serializerSettings = new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects };
            string json = JsonConvert.SerializeObject(values, Formatting.Indented, serializerSettings);



            //string json = JsonConvert.SerializeObject(values);
            return json;
        }

        /// <summary>
        /// Receive a value type of T. Return a Json.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="values"></param>
        /// <returns></returns>
        public static string ConvertRequestToJson<T>(T values)
        {
            string json = JsonConvert.SerializeObject(values);
            return json;
        }

        #endregion

        /// <summary>
        /// Validate Expired Password
        /// </summary>
        /// <param name="pwdLog"></param>
        public static bool ValidatePasswordExpiration(IList<UserPwdHistoryDto> result, int days)
        {
            var lastPasswordDate = result.OrderByDescending(x => x.PwdModifyDate).Select(x => x.PwdModifyDate).FirstOrDefault();

            if (Convert.ToDateTime(lastPasswordDate) < DateTime.Now.AddDays(days))
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        #region EXCEPTION MANAGER
        /// <summary>
        /// Return Exeption message with user Id and where was the error.
        /// </summary>
        /// <param name="e"></param>
        /// <param name="controllerContext"></param>
        /// <returns></returns>
        public static string ReturnExMsg(Exception e, string controllerAction)
        {
            string expMsg = string.Empty;

            var messages = e.FromHierarchy(ex => ex.InnerException).Select(ex => ex.Message);
            expMsg = string.Join(Environment.NewLine, messages.ToArray());
            string result = string.Format("{0}\r\n{1}", controllerAction, expMsg);

            return result;
        }

        private static IEnumerable<TSource> FromHierarchy<TSource>(
         this TSource source,
         Func<TSource, TSource> nextItem,
         Func<TSource, bool> canContinue)
        {
            for (var current = source; canContinue(current); current = nextItem(current))
            {
                yield return current;
            }
        }

        private static IEnumerable<TSource> FromHierarchy<TSource>(
            this TSource source,
            Func<TSource, TSource> nextItem)
            where TSource : class
        {
            return FromHierarchy(source, nextItem, s => s != null);
        }

        public static string GetControllerActionRoute(ApiController controller)
        {
            return controller.ControllerContext.ControllerDescriptor.ControllerName + "/" + controller.ActionContext.ActionDescriptor.ActionName;
        }

        #endregion
    }
}
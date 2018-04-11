using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PasswordPolicy.Models.MMPAY.DTOs
{
    public class UserPwdHistoryDto
    {
        public int UserId { get; set; }
        public string Password { get; set; }
        public DateTime PwdModifyDate { get; set; }
        public int PwdModifyBy { get; set; }
    }
}
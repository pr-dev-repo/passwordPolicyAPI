using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PasswordPolicy.Models.MMPAY
{
    [Table("CPSUserPwdLog")]
    public class CPSUserPwdLog
    {
        [Key]
        public int UserPwdLogKey { get; set; }
        public string Password { get; set; }
        public DateTime PwdModifyDate { get; set; }
        public int PwdModifyBy { get; set; }
        public int UserId { get; set; }
    }
}
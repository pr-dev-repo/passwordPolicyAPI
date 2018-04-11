using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PasswordPolicy.Models.MMPAY
{
    [Table("CPSUsers")]
    public class CPSUsers
    {

        [Key]
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        [EmailAddress]
        [StringLength(50, MinimumLength = 1)]
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleID { get; set; }
        public int? UserStatus { get; set; }
        public int? GroupID { get; set; }
        public DateTime DateCreated { get; set; }
        public int? BranchId { get; set; }
        public bool? Blocked { get; set; }
        public int? CreatedByUserId { get; set; }
        public DateTime? CreatedOnDate { get; set; }
        public int? LastModifiedByUserId { get; set; }
        public DateTime? LastModifiedOnDate { get; set; }
        public bool? AllMerchants { get; set; }

        [ForeignKey("UserID")]
        public virtual CPSUsersExtended UserExtInfo { get; set; }

    }
}
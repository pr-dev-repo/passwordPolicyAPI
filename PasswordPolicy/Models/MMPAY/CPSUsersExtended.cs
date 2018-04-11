using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PasswordPolicy.Models.MMPAY
{
    [Table("CPSUsersExtended")]
    public class CPSUsersExtended
    {
        [Key]
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [EmailAddress]
        [StringLength(50, MinimumLength = 1)]
        public string Email { get; set; }
        public int? CostCenter { get; set; }
        public string CPSPasswordQuestionCode { get; set; }
        public string CPSPasswordAnswer { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public DateTime? LastPasswordChangeDate { get; set; }
        public DateTime? LastLockoutDate { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int? FailedPasswordAttemptCount { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int? FailedPasswordAnswerAttemptCount { get; set; }
        public Guid? ForgotPasswordToken { get; set; }
        public DateTime? ForgotPasswordTokenDate { get; set; }
        public bool? ForgotPasswordTokenUsed { get; set; }
        public bool? VoidPermission { get; set; }
        public bool? RefundPermission { get; set; }
        public bool? UserCreationPermission { get; set; }
        public bool? SendEmailNotification { get; set; }
        public bool? SecurityQuestionReset { get; set; }
        public bool? PasswordReset { get; set; }
        public int? SelfRegisteredTries { get; set; }

        public virtual CPSUsers User { get; set; }

    }
}
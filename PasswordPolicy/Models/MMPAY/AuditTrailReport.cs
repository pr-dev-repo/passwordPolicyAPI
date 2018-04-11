using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PasswordPolicy.Models.MMPAY
{
    //[NotMapped]
    public class AuditTrailReport
    {
        [Key]
        public int AuditTrailID { get; set; }
        public int OperatorID { get; set; }
        public string OperatorUsername { get; set; }
        public short AuditTrailActionID { get; set; }
        public string ActionName { get; set; }
        public string ChangeDescription { get; set; }
        public string RolesDesc { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
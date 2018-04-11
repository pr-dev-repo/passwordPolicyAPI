using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PasswordPolicy.Models.MMPAY
{
    [Table("AuditTrail")]
    public class AuditTrail
    {
        [Key]
        public int AuditTrailID { get; set; }
        public short AuditTrailActionID { get; set; } // FK
        public int? OperatorID { get; set; } //FK
        public string AuditTrailEntityKey { get; set; }
        public string ChangeDescription { get; set; }
        public DateTime CreatedOn { get; set; }

        //public virtual CPSUsers CPSUsers { get; set; }
        public virtual AuditTrailAction AuditTrailAction { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PasswordPolicy.Models.MMPAY
{
    [Table("AuditTrailEntity")]
    public class AuditTrailEntity
    {
        public AuditTrailEntity()
        {
            this.AuditTrailAction = new HashSet<AuditTrailAction>();
        }

        [Key]
        public byte AuditTrailEntityID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<AuditTrailAction> AuditTrailAction { get; set; }
    }
}
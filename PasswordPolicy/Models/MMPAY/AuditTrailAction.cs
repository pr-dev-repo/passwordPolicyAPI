using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PasswordPolicy.Models.MMPAY
{
    [Table("AuditTrailAction")]
    public class AuditTrailAction
    {
        public AuditTrailAction()
        {
            this.AuditTrail = new HashSet<AuditTrail>();
        }

        [Key]
        public short AuditTrailActionID { get; set; }
        public byte AuditTrailEntityID { get; set; } //FK
        public string Name { get; set; }
        public int Status { get; set; }

        public virtual AuditTrailEntity AuditTrailEntity { get; set; }
        public virtual ICollection<AuditTrail> AuditTrail { get; set; }
    }
}
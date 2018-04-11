using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PasswordPolicy.Models.MMPAY
{
    [Table("EventLog")]
    public class EventLog
    {
        [Key]
        public int ID { get; set; }
        public int EventID { get; set; }
        public string LogLevel { get; set; }
        public string Message { get; set; }
        public int UserID { get; set; }
        public string Location { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
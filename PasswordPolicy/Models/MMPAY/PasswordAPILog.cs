using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PasswordPolicy.Models.MMPAY
{
    public class PasswordAPILog
    {
        [Key]
        public long Log_Key { get; set; }
        public string Merchant_Number { get; set; }
        public string XML_Request { get; set; }
        public string XML_Response { get; set; }
        public string Additional_Info { get; set; }
        public int Response_Code { get; set; }
        public DateTime Process_Date { get; set; }
    }
}
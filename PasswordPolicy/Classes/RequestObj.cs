using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PasswordPolicy.Classes
{
    public class RequestObj
    {
        // password
        public string Password { get; set; }
        public int UserId { get; set; }
        public string Email { get; set; }

        // validation
        public bool ParamsAreValid { get; set; }
        public string ErrorMsg { get; set; }
    }
}
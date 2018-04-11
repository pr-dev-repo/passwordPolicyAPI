using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PasswordPolicy
{
    public class PasswordPolicy
    {
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d{4})[a-zA-Z\d{4}]{8,32}$", ErrorMessage = "The password does not match the required complexity.")]
        [Required]
        public string Password { get; set; }

        public int UserId { get; set; }
    }
}
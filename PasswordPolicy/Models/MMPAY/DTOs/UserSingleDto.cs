using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PasswordPolicy.Models.MMPAY.DTOs
{
    public class UserSingleDto
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Blocked { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseClass.BL;

namespace CourseClass.API.Models.LoginModel
{
    public class AuthResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
        public int Phone { get; set; }
        public string Token { get; set; }
    }
}
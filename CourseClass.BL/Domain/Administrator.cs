using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace CourseClass.BL.Domain
{
    public class Administrator
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public int Phone { get; set; }
    }
}
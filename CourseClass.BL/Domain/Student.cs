using System;
using System.Collections.Generic;
using System.Text;

namespace CourseClass.BL.Domain
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public string Image { get; set; }
        public List<Course> Courses { get; set; }
    }
}
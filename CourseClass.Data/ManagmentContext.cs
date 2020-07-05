using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using CourseClass.BL.Domain;

namespace CourseClass.Data
{
    public class ManagmentContext : DbContext
    {
        public ManagmentContext(DbContextOptions<ManagmentContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Administrator> Admins { get; set; }
    }
}
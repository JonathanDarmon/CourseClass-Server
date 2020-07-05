using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CourseClass.BL.Domain;

namespace CourseClass.BL.Contracts
{
    public interface ICourseRepository
    {
        IEnumerable<Course> AllCourses { get; }
        Course GetCourseById(int courseId);
        Task<bool> AddCourse(Course course);
        Task<bool> UpdateCourse(Course course);
        Task<bool> DeleteCourse(int courseId);
        void Commit();
    }
}
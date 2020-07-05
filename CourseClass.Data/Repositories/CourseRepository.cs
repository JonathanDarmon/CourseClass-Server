using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CourseClass.BL.Contracts;
using CourseClass.BL.Domain;
using System.Linq;

namespace CourseClass.Data.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ManagmentContext _context;
        public CourseRepository(ManagmentContext context)
        {
            _context = context;
        }

        public IEnumerable<Course> AllCourses
        {
            get
            {
                var query = from a in _context.Courses
                            select a;
                return query;
            }
        }

        public Task<bool> AddCourse(Course course)
        {
            if (course == null)
            {
                return Task.FromResult(false);
            }
            else
            {
                _context.Courses.Add(course);
                Commit();
                return Task.FromResult(true);
            }

        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public Task<bool> DeleteCourse(int courseId)
        {
            var course = GetCourseById(courseId);
            if (course != null)
            {
                _context.Courses.Remove(course);
                Commit();
                return Task.FromResult(true);
            }
            else
            {
                return Task.FromResult(false);
            }
        }

        public Course GetCourseById(int courseId)
        {
            return _context.Courses.FirstOrDefault(c => c.Id == courseId);
        }

        public Task<bool> UpdateCourse(Course course)
        {
            if (course != null)
            {
                _context.Courses.Update(course);
                Commit();
                return Task.FromResult(true);
            }
            else
            {
                return Task.FromResult(false);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CourseClass.BL.Contracts;
using CourseClass.BL.Domain;
using System.Linq;

namespace CourseClass.Data.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ManagmentContext _context;
        public StudentRepository(ManagmentContext context)
        {
            _context = context;
        }
        public IEnumerable<Student> AllStudents
        {
            get
            {
                var query = from a in _context.Students
                            select a;
                return query;
            }
        }

        public Task<bool> AddStudent(Student student)
        {
            if (student == null)
            {
                return Task.FromResult(false);
            }
            else
            {
                _context.Students.Add(student);
                Commit();
                return Task.FromResult(true);
            }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public Task<bool> DeleteStudent(int studentId)
        {
            var student = GetStudentById(studentId);
            if (student != null)
            {
                _context.Students.Remove(student);
                Commit();
                return Task.FromResult(true);
            }
            else
            {
                return Task.FromResult(false);
            }
        }

        public Student GetStudentById(int studentId)
        {
            return _context.Students.FirstOrDefault(s => s.Id == studentId);
        }

        public Task<bool> UpdateStudent(Student student)
        {
            if (student != null)
            {
                _context.Students.Update(student);
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
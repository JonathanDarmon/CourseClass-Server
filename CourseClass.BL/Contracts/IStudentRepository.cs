using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CourseClass.BL.Domain;

namespace CourseClass.BL.Contracts
{
    public interface IStudentRepository
    {
        IEnumerable<Student> AllStudents { get; }
        Student GetStudentById(int studentId);
        Task<bool> AddStudent(Student student);
        Task<bool> UpdateStudent(Student student);
        Task<bool> DeleteStudent(int studentId);
        void Commit();
    }
}
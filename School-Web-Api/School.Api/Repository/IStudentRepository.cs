using School.API.Domain;
using System.Collections.Generic;

namespace School.API.Repository
{
    public interface IStudentRepository
    {
        void AddStudent(Student student);

        List<Student> GetAllStudents();

        Student GetStudentById(int id);

        void DeleteStudent(int id);
    }
}
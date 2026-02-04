using School.API.Domain;
using System.Collections.Generic;

namespace School.API.Service
{
    public interface IStudentService
    {
        void AdaugaStudent(string nume, int nota);

        List<Student> ObtineTotiStudentii();

        void StergeStudent(int id);

        (int promovati, int picati) CalculeazaStatistici();
    }
}
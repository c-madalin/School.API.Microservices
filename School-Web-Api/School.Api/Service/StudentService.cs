using School.API.Domain;
using School.API.Repository; 
using System;
using System.Collections.Generic;
using System.Linq; 

namespace School.API.Service
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public void AdaugaStudent(string nume, int media)
        {
            if (string.IsNullOrWhiteSpace(nume))
            {
                throw new ArgumentException("Numele studentului nu poate fi gol.");
            }
            if (media < 1 || media > 10)
            {
                throw new ArgumentException("Media trebuie să fie între 1 și 10.");
            }
            var studentNou = new Student
            {
                Nume = nume,
                Medie = media
            };

            _studentRepository.AddStudent(studentNou);
        }

        public (int promovati, int picati) CalculeazaStatistici()
        {
            var studenti = _studentRepository.GetAllStudents();

            int promovati = studenti.Count(s => s.Medie >= 5);
            int picati = studenti.Count(s => s.Medie < 5);

            return (promovati, picati);
        }

        public List<Student> ObtineTotiStudentii()
        {
            return _studentRepository.GetAllStudents();
        }

        public void StergeStudent(int id)
        {
            var student = _studentRepository.GetStudentById(id);
            if (student == null)
            {
                throw new ArgumentException("Studentul cu ID-ul specificat nu există.");
            }
            _studentRepository.DeleteStudent(id);
        }
    }
}
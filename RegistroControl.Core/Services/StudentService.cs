using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RegistroControl.Core.Entities;
using RegistroControl.Core.Interfaces;

namespace RegistroControl.Core.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public Task<bool> DeleteStudent(int id)
        {
            return _studentRepository.DeleteStudent(id);
            
        }

        public Task<Student> GetStudent(int idStudent)
        {
            return _studentRepository.GetStudent(idStudent);
        }

        public Task<IEnumerable<Student>> GetStudents()
        {
            return _studentRepository.GetStudents();
        }

        public async Task InsertStudent(Student student)
        {
            await _studentRepository.InsertStudent(student);
        }

        public Task<bool> UpdateStudent(Student student)
        {
            return _studentRepository.UpdateStudent(student);
        }
    }
}

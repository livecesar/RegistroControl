using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RegistroControl.Core.Entities;
using RegistroControl.Core.Interfaces;

namespace RegistroControl.Core.Services
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StudentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<bool> DeleteStudent(int id)
        {
            return _unitOfWork.StudentRepository.DeleteStudent(id);
            
        }

        public Task<Student> GetStudent(int idStudent)
        {
            return _unitOfWork.StudentRepository.GetStudent(idStudent);
        }

        public Task<IEnumerable<Student>> GetStudents()
        {
            return _unitOfWork.StudentRepository.GetStudents();
        }

        public async Task InsertStudent(Student student)
        {
            await _unitOfWork.StudentRepository.InsertStudent(student);
            await _unitOfWork.SavechangesAsync();
        }

        public async Task<bool> UpdateStudent(Student student)
        {
            await _unitOfWork.StudentRepository.UpdateStudent(student);
            await _unitOfWork.SavechangesAsync();
            return true;
        }
    }
}

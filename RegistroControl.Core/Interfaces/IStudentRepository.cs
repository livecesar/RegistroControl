using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RegistroControl.Core.Entities;

namespace RegistroControl.Core.Interfaces
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetStudents();
        Task<Student> GetStudent(int idStudent);
        Task InsertStudent(Student student);
    }
}

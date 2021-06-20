using System.Collections.Generic;
using System.Threading.Tasks;
using RegistroControl.Core.Entities;

namespace RegistroControl.Core.Interfaces
{
    public interface IStudentService
    {
        Task InsertStudent(Student student);
        Task<IEnumerable<Student>> GetStudents();
        Task<Student> GetStudent(int idStudent);
        Task<bool> DeleteStudent(int id);
        Task<bool> UpdateStudent(Student student);
    }
}
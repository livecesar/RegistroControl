using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RegistroControl.Core.Entities;
using RegistroControl.Core.Interfaces;
using RegistroControl.Infrastructure.Data;

namespace RegistroControl.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly RegistroControlContext _context;

        public StudentRepository(RegistroControlContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {       
            var students = await _context.Students.ToListAsync();
            return students;
        }

        public async Task<Student> GetStudent(int id)
        {
            var student = await _context.Students.FirstOrDefaultAsync(s=>s.StudentId == id);
            return student;
        }

        public async Task InsertStudent(Student student)
        {
            _context.Students.Add(student);
        }

        public async Task<bool> DeleteStudent(int id)
        {
            var currentStudent = await GetStudent(id);
            currentStudent.Active = false;

            return true;
        }

        public async Task<bool> UpdateStudent(Student student)
        {
            var currentStudent = await GetStudent(student.StudentId);
            currentStudent.Phone = student.Phone;
            currentStudent.Cellphone = student.Cellphone;
            currentStudent.StudentAddress = student.StudentAddress;

            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RegistroControl.Core.Entities;
using RegistroControl.Core.Interfaces;
using RegistroControl.Infrastructure.Data;

namespace RegistroControl.Infrastructure.Repositories
{
    public class CourseStudentRepository : ICourseStudentRepository
    {
        private readonly RegistroControlContext _context;

        public CourseStudentRepository(RegistroControlContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CourseStudent>> GetCourseStudent()
        {
            var courseStudents = await _context.CourseStudents.ToListAsync();
            return courseStudents;
        }

        public async Task<CourseStudent> GetCourseStudent(int id)
        {
            var courseStudent = await _context.CourseStudents.FirstOrDefaultAsync(x => x.CourseStudentId == id);
            return courseStudent;
        }

        public Task<bool> DeleteCourseStudent(int id)
        {
            throw new NotImplementedException();
        }

        public async Task InsertCourseStudent(CourseStudent courseStudent)
        {
            _context.CourseStudents.Add(courseStudent);
        }

        public Task<bool> UpdateCourseStudent(CourseStudent courseStudent)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RegistroControl.Core.Entities;

namespace RegistroControl.Core.Interfaces
{
    public interface ICourseStudentRepository
    {
        Task<IEnumerable<CourseStudent>> GetCoursesStudent();
        Task<bool> CourseAlreadyForStudent(int idCourse, int idStudent);
        Task<CourseStudent> GetCourseStudent(int id);
        Task InsertCourseStudent(CourseStudent courseStudent);
        Task<bool> DeleteCourseStudent(int id);
        Task<bool> UpdateCourseStudent(CourseStudent courseStudent);
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RegistroControl.Core.Entities;

namespace RegistroControl.Core.Interfaces
{
    public interface ICourseStudentService
    {
        Task InsertCourseStudent(CourseStudent student);
        Task<IEnumerable<CourseStudent>> GetCourseStudent();
        Task<CourseStudent> GetCourseStudent(int id);
        Task<bool> DeleteCourseStudent(int id);
        Task<bool> UpdateCourseStudent(CourseStudent courseStudent);
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RegistroControl.Core.CustomEntities;
using RegistroControl.Core.Entities;
using RegistroControl.Core.QueryFilters;

namespace RegistroControl.Core.Interfaces
{
    public interface ICourseStudentService
    {
        Task InsertCourseStudent(CourseStudent student);
        PagedList<CourseStudent> GetCoursesStudent(CourseStudentQueryFilter filter);
        Task<CourseStudent> GetCourseStudent(int id);
        Task<bool> DeleteCourseStudent(int id);
        Task<bool> CourseAlreadyForStudent(int idCourse, int idStudent);
        Task<bool> UpdateCourseStudent(CourseStudent courseStudent);
    }
}

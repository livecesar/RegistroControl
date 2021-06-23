using System;
using RegistroControl.Core.QueryFilters;

namespace RegistroControl.Infrastructure.Interfaces
{
    public interface IUriService
    {
        Uri GetCourseStudentPaginationUri(CourseStudentQueryFilter filter, string actionUrl);
    }
}
using System;
namespace RegistroControl.Core.QueryFilters
{
    public class CourseStudentQueryFilter
    {
        public int? IdCourse { get; set; }
        public int? IdStudent { get; set; }
        public bool? Active { get; set; }
    }
}

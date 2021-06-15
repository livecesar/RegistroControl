using System;
using System.Collections.Generic;

#nullable disable

namespace RegistroControl.Core.Entities
{
    public partial class Course
    {
        public Course()
        {
            CourseStudents = new HashSet<CourseStudent>();
        }

        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<CourseStudent> CourseStudents { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace RegistroControl.Core.Entities
{
    public partial class CourseStudent
    {
        public int CourseStudentId { get; set; }
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public DateTime RelateDate { get; set; }
        public bool Active { get; set; }

        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
    }
}

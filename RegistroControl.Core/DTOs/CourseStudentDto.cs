using System;
namespace RegistroControl.Core.DTOs
{
    public class CourseStudentDto
    {
        public int CourseStudentId { get; set; }
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public DateTime RelateDate { get; set; }
        public bool Active { get; set; }
    }
}

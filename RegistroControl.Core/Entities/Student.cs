using System;
using System.Collections.Generic;

#nullable disable

namespace RegistroControl.Core.Entities
{
    public partial class Student
    {
        public Student()
        {
            CourseStudents = new HashSet<CourseStudent>();
        }

        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentSurname { get; set; }
        public string DniNumber { get; set; }
        public string Cellphone { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }
        public string StudentAddress { get; set; }
        public bool Active { get; set; }
        public int CityId { get; set; }
        public int DniTypeId { get; set; }
        public int? SystemUserId { get; set; }

        public virtual City City { get; set; }
        public virtual DniType DniType { get; set; }
        public virtual SystemUser SystemUser { get; set; }
        public virtual ICollection<CourseStudent> CourseStudents { get; set; }
    }
}

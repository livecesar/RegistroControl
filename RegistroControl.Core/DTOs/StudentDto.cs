using System;
namespace RegistroControl.Core.DTOs
{
    public class StudentDto
    {
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
    }
}

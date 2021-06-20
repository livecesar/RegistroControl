using System;
using System.Collections.Generic;

#nullable disable

namespace RegistroControl.Core.Entities
{
    public class City
    {
        public City()
        {
            Administrators = new HashSet<Administrator>();
            Students = new HashSet<Student>();
            Department = new Department();
        }

        public int CityId { get; set; }
        public string CityName { get; set; }
        public int DepartmentId { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<Administrator> Administrators { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual Department Department { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace RegistroControl.Core.Entities
{
    public class Department
    {
        public Department()
        {
            Cities = new HashSet<City>();
        }

        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<City> Cities { get; set; }
    }
}

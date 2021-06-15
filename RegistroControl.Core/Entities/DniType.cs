using System;
using System.Collections.Generic;

#nullable disable

namespace RegistroControl.Core.Entities
{
    public partial class DniType
    {
        public DniType()
        {
            Administrators = new HashSet<Administrator>();
            Students = new HashSet<Student>();
        }

        public int DniId { get; set; }
        public string DniName { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<Administrator> Administrators { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}

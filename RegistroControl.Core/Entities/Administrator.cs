using System;
using System.Collections.Generic;

#nullable disable

namespace RegistroControl.Core.Entities
{
    public partial class Administrator
    {
        public int AdminId { get; set; }
        public string AdminName { get; set; }
        public string AdminSurname { get; set; }
        public string DniNumber { get; set; }
        public string Cellphone { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }
        public string AdminAddress { get; set; }
        public bool Active { get; set; }
        public int CityId { get; set; }
        public int DniTypeId { get; set; }
        public int? SystemUserId { get; set; }

        public virtual City City { get; set; }
        public virtual DniType DniType { get; set; }
        public virtual SystemUser SystemUser { get; set; }
    }
}

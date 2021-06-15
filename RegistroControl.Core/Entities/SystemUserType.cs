using System;
using System.Collections.Generic;

#nullable disable

namespace RegistroControl.Core.Entities
{
    public partial class SystemUserType
    {
        public SystemUserType()
        {
            EventLogs = new HashSet<EventLog>();
        }

        public int UserTypeId { get; set; }
        public string UserTypeName { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<EventLog> EventLogs { get; set; }
    }
}

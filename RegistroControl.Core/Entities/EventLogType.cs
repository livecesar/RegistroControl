using System;
using System.Collections.Generic;

#nullable disable

namespace RegistroControl.Core.Entities
{
    public partial class EventLogType
    {
        public EventLogType()
        {
            EventLogs = new HashSet<EventLog>();
        }

        public int EventLogTypeId { get; set; }
        public string EventTypeName { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<EventLog> EventLogs { get; set; }
    }
}

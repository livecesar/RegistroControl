using System;
using System.Collections.Generic;

#nullable disable

namespace RegistroControl.Core.Entities
{
    public partial class EventLog
    {
        public int EventLogId { get; set; }
        public string SysUser { get; set; }
        public int EventLogTypeId { get; set; }
        public int SysUserTypeId { get; set; }
        public DateTime EventDate { get; set; }

        public virtual EventLogType EventLogType { get; set; }
        public virtual SystemUserType SysUserType { get; set; }
    }
}

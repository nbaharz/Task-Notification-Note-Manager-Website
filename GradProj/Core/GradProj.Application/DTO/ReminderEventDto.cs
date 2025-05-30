using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradProj.Application.DTO
{
    public class ReminderEventDto
    {
        public Guid EventId { get; set; }
        public Guid UserId { get; set; }
        public DateTime ReminderTime { get; set; }
        public string Message { get; set; } = string.Empty;
        //public ReferenceType = "Event" //enum yerine burda boyle tanimlanabilir.
    }
}

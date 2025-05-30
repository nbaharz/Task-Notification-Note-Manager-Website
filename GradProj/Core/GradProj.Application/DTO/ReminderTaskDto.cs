using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GradProj.Domain.Entities;

namespace GradProj.Application.DTO
{
    public class ReminderTaskDto
    {
        public Guid TaskId { get; set; }
        public Guid UserId { get; set; }
        public DateTime ReminderTime { get; set; }
        public string Message { get; set; } = string.Empty;
        //public ReferenceType = "Task" //enum yerine burda boyle tanimlanabilir.
    }
}

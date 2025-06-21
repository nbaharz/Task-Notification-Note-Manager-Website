using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GradProj.Domain.Entities;

namespace GradProj.Application.DTO
{
    public class ReminderBaseDto
    {
        public Guid UserId { get; set; }
        public Guid ReferenceId { get; set; }
        public string ReferenceType { get; set; }
        public DateTime ReminderTime { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}

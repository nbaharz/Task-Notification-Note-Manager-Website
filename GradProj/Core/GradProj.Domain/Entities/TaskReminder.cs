using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradProj.Domain.Entities
{
    public class TaskReminder
    {
        public int ID { get; set; }
        public int UserTaskID { get; set; }
        public DateTime ReminderTime { get; set; }
        public string Message { get; set; } = string.Empty;

        [ForeignKey(nameof(UserTaskID))]
        public virtual User_Tasks UserTask { get; set; }
    }
}

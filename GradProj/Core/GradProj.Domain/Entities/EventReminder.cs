using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradProj.Domain.Entities
{
    public class EventReminder
    {
        public int ID { get; set; }
        public int UserEventID { get; set; }
        public DateTime ReminderTime { get; set; }
        public string Message { get; set; } = string.Empty;

        [ForeignKey(nameof(UserEventID))]
        public virtual UserEvents UserEvents { get; set; }
    }
}

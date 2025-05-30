using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradProj.Domain.Entities
{
    public class TaskAnalytics: BaseEntity
    {
        public Guid UserId { get; set; }

        public DateTime PeriodStart { get; set; } //analizin baslatildigi tarih
        public DateTime PeriodEnd { get; set; }

        public int TotalHighPriorityTasks { get; set; }
        public int CompletedHighPriorityTasks { get; set; }

        public int TotalMediumPriorityTasks { get; set; }
        public int CompletedMediumPriorityTasks { get; set; }

        public int TotalLowPriorityTasks { get; set; }
        public int CompletedLowPriorityTasks { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User? User { get; set; }

    }
}

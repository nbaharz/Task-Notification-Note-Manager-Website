using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradProj.Domain.Entities
{
    public class Task
    {
        public int ID { get; set; }

        [Required]
        public int UserID { get; set; }

        [Required]
        public string Item { get; set; } = string.Empty;

        [EnumDataType(typeof(TaskPriority))]
        public TaskPriority Priority { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool IsCompleted { get; set; } = false;

        [ForeignKey(nameof(UserID))]
        public virtual User? User { get; set; }
    }

    public enum TaskPriority
    {
        High,
        Medium,
        Low
    }
}

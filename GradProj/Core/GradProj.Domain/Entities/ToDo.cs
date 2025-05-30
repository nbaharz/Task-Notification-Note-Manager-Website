using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradProj.Domain.Entities
{
    public class ToDo:BaseEntity
    {
        [Required]
        public Guid UserId { get; set; }

        [Required]
        public string Item { get; set; } = string.Empty;

        [EnumDataType(typeof(TaskPriority))]
        public TaskPriority Priority { get; set; }

        public bool IsCompleted { get; set; } = false;

        [ForeignKey(nameof(UserId))]
        public virtual User? User { get; set; }
    }

    public enum TaskPriority 
    {
        High,
        Medium,
        Low
    }
}

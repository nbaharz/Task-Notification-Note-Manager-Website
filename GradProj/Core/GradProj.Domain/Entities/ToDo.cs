using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradProj.Domain.Entities
{
    [Table("Task")]
    public class ToDo:BaseEntity 
    {
        [Required]
        public Guid UserId { get; set; }

        //title ekle
        [Required]
        public string Title { get; set; } = string.Empty;
        public  string Description { get; set; } = string.Empty;

        [EnumDataType(typeof(TaskPriority))]
        public TaskPriority Priority { get; set; }

        public bool IsCompleted { get; set; } = false;

        [ForeignKey(nameof(UserId))]
        public virtual User? User { get; set; }
        public ReferenceType ReferenceType => ReferenceType.Event;
    }

    public enum TaskPriority 
    {
        High,
        Medium,
        Low
    }
}

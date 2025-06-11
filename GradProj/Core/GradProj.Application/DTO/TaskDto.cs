using GradProj.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradProj.Application.DTO
{
    public class TaskDto
    {
        public Guid UserId { get; set; }      
        public string Item { get; set; } = string.Empty;

        [EnumDataType(typeof(TaskPriority))]
        public TaskPriority Priority { get; set; }

        
    }
    
}

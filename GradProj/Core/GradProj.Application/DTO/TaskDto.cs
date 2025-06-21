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
        
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        [EnumDataType(typeof(TaskPriority))]
        public TaskPriority Priority { get; set; }

        
    }
    
}

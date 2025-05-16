using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradProj.Domain.Entities
{
    public class User_Tasks:BaseEntity
    {
        public Guid UserId { get; set; }  
        public Guid TaskId { get; set; }  

        // Navigation properties
        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }

        [ForeignKey(nameof(TaskId))]
        public virtual ToDo Task { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradProj.Domain.Entities
{
    public class Notification:BaseEntity 
    {
        public Guid UserId { get; set; }
        public string Message { get; set; } = string.Empty;
        
        public bool IsRead = false;
        [ForeignKey(nameof(UserId))]
        public virtual User? User { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradProj.Domain.Entities
{
    public class Notification
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public string Message { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public bool IsRead = false;
        [ForeignKey(nameof(UserID))]
        public virtual User? User { get; set; }

    }
}

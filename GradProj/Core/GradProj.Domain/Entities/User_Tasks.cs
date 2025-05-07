using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradProj.Domain.Entities
{
    public class User_Tasks
    {
        public int ID { get; set; }  // UserTask unique ID
        public int UserID { get; set; }  // Hangi kullanıcıya ait
        public int TaskID { get; set; }  // Task'ın ID'si

        // Navigation properties
        [ForeignKey(nameof(UserID))]
        public virtual User User { get; set; }

        [ForeignKey(nameof(TaskID))]
        public virtual Task Task { get; set; }
    }
}

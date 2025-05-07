using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradProj.Domain.Entities
{
    public class UserEvents
    {
        public int ID { get; set; }  // UserEvent unique ID
        public int UserID { get; set; }  // Hangi kullanıcıya ait
        public int EventID { get; set; }  // Event'in ID'si

        // Navigation properties
        [ForeignKey(nameof(UserID))]
        public virtual User User { get; set; }

        [ForeignKey(nameof(EventID))]
        public virtual Event Event { get; set; }
    }
}

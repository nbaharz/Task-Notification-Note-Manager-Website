using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradProj.Domain.Entities
{
    public class UserEvents:BaseEntity
    {
        public int UserId { get; set; }  // Hangi kullanıcıya ait
        public int EventId { get; set; }  // Event'in ID'si

        // Navigation properties
        [ForeignKey(nameof(UserId))]
        public virtual required User User { get; set; }

        [ForeignKey(nameof(EventId))]
        public virtual required Event Event { get; set; }
    }
}

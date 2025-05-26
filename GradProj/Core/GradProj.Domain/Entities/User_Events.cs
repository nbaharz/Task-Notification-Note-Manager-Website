using System;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradProj.Domain.Entities
{
    public class User_Events:BaseEntity
    {
        public Guid UserId { get; set; }  // Hangi kullanıcıya ait
        public Guid EventId { get; set; }  // Event'in ID'si

        // Navigation properties
        [ForeignKey(nameof(UserId))]
        public virtual  User? User { get; set; }

        [ForeignKey(nameof(EventId))]
        public virtual  Event? Event { get; set; }
    }
}

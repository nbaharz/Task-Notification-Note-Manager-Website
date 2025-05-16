using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradProj.Domain.Entities
{
    public class UserTrackedProducts:BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid TrackedProductId { get; set; }
        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; } = null!;

        [ForeignKey(nameof(TrackedProductId))]
        public virtual TrackedProducts TrackedProducts { get; set; } = null!;
    }
}

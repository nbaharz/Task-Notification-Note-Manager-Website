using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradProj.Domain.Entities
{
    public class Goal:BaseEntity
    {
        public Guid UserId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        [EnumDataType(typeof(TimeFrame))]
        public TimeFrame TimeFrame { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public int Progress { get; set; } = 0;

        [ForeignKey(nameof(UserId))]
        public virtual User? User { get; set; }
    }

    public enum TimeFrame
    {
        Weekly,
        Monthly,
        Yearly,
    }
}

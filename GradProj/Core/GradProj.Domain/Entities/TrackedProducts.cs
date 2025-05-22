using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GradProj.Domain.Entities
{
    public class TrackedProducts: BaseEntity
    {
        public string Name { get; set; }
        public bool IsDiscounted { get; set; } = false;
        public Uri Url { get; set; }
        public decimal CurrentPrice { get; set; }
        public DateTime LastCheckedDate { get; set; }
      
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GradProj.Domain.Entities
{
    public class TrackedProducts: BaseEntity
    {
        public string url { get; set; }
        public string? ProductTitle { get; set; }
        public decimal? Price { get; set; }       
        public string? PriceSaving { get; set; }
        public string? ProductRating { get; set; }        

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradProj.Application.DTO
{
    public class ProductDetailDto
    {
        public string? ProductTitle { get; set; }
        public decimal? Price { get; set; }
        public decimal? RetailPrice { get; set; }
        public string? PriceSaving { get; set; }
        public string? ProductRating { get; set; }
        public string? Seller { get; set; }
    }
}

using GradProj.Application.DTO;
using GradProj.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradProj.Application.ServiceAbs
{
    public interface IAmazonProductService
    {
        Task<ProductDetailDto> GetProductDetailsAsync(string amazonUrl);
        Task<DiscountInfoDto> GetDiscountInfoAsync(string amazonUrl); //dto koy
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GradProj.Application.DTO;
using GradProj.Domain.Entities;

namespace GradProj.Application.ServiceAbs
{
    public interface ITrackedProductsService : IService<TrackedProducts>
    {
        Task<ProductDetailDto> GetProductFromAmazon(string amazonurl,Guid userid);
        Task<object> GetDiscountInfoAsync(string amazonUrl);
  
    }
}

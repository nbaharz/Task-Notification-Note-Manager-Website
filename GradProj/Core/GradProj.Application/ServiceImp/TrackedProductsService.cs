using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GradProj.Application.DTO;
using GradProj.Application.ServiceAbs;
using GradProj.Domain.Entities;
using GradProj.Domain.RepositoryAbs;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GradProj.Application.ServiceImp
{
    public class TrackedProductsService : GenericService<TrackedProducts>, ITrackedProductsService
    {
        private readonly ITrackedProductsRepository _trackedProductsRepository;
        protected readonly IAmazonProductService _amazonProductService;
        protected readonly IUserTrackedProductsRepository _userTrackedProductsRepository;
        public TrackedProductsService(ITrackedProductsRepository trackedProductsRepository, IAmazonProductService amazonProductService, IUserTrackedProductsRepository userTrackedProductsRepository) : base(trackedProductsRepository)
        {
            _trackedProductsRepository = trackedProductsRepository;
            _amazonProductService = amazonProductService;
            _userTrackedProductsRepository = userTrackedProductsRepository;
        }
       public async Task<ProductDetailDto> GetProductFromAmazon(string amazonurl, Guid userid) {

            var data = await _amazonProductService.GetProductDetailsAsync(amazonurl);
            var checkedproduct = _trackedProductsRepository.GetSingleAsync(x=>x.url == amazonurl).FirstOrDefault();
            if (checkedproduct != null)
            {
                _trackedProductsRepository.UpdateAsync(checkedproduct);

            }
            else
            {

                 checkedproduct = new TrackedProducts
                {
                    url = amazonurl,
                    ProductTitle = data.ProductTitle,
                    Price = data.Price,
                    PriceSaving = data.PriceSaving,
                    ProductRating = data.ProductRating,

                };
                 _trackedProductsRepository.AddAsync(checkedproduct);
                

            }
           
            var isExistsAtUserProduct = new UserTrackedProducts
            {
                UserId = userid,
                TrackedProductId = checkedproduct.Id
            };
            if (!_userTrackedProductsRepository.Exists(isExistsAtUserProduct))
            {
                _userTrackedProductsRepository.AddAsync(isExistsAtUserProduct);
            }


            return data;            
        }
        public async Task<object> GetDiscountInfoAsync(string amazonUrl)
        {
          return await  _amazonProductService.GetDiscountInfoAsync(amazonUrl);
        }
    }
}

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
                    CurrentPrice = data.Price,
                    PriceSaving = data.PriceSaving,
                    ProductRating = data.ProductRating,
                    LastFetchTime= data.LastFetchTime,

                };
                 await _trackedProductsRepository.AddAsync(checkedproduct);
                
            }
           
            var isExistsAtUserProduct = new UserTrackedProducts
            {
                UserId = userid,
                TrackedProductId = checkedproduct.Id
            };
            if (!_userTrackedProductsRepository.Exists(isExistsAtUserProduct))
            {
                await _userTrackedProductsRepository.AddAsync(isExistsAtUserProduct);
            }


            return data;            
        }
        public async Task<object> GetDiscountInfoAsync(string amazonUrl)
        {
          return await  _amazonProductService.GetDiscountInfoAsync(amazonUrl);
        }

        public List<TrackedProducts> GetSpecifiedUserProducts(Guid userid)
        {
           var userTrackedProducts =  _userTrackedProductsRepository.GetSingleAsync(u => u.UserId == userid).ToList();
            var productIds = userTrackedProducts
      .Select(utp => utp.TrackedProductId)
      .ToList();
            return  _trackedProductsRepository.GetSingleAsync(p => productIds.Contains(p.Id)).ToList();

        }
        public void DeleteUserTask(Guid objectid)
        {
            _userTrackedProductsRepository.DeleteAsync(objectid);
        }
    }
}

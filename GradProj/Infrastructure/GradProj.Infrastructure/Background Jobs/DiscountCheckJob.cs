using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GradProj.Application.DTO;
using GradProj.Application.ServiceAbs;
using GradProj.Domain.Entities;
using GradProj.Domain.RepositoryAbs;

namespace GradProj.Infrastructure.Background_Jobs
{
    public class DiscountCheckJob
    {
        private readonly ITrackedProductsRepository _trackedProductsRepository;
        private readonly IUserTrackedProductsRepository _userTrackedRepository;
        private readonly IAmazonProductService _amazonService;
        private readonly INotificationService _notificationService;

        public DiscountCheckJob(
            ITrackedProductsRepository trackedProductsRepository,
            IUserTrackedProductsRepository userTrackedRepository,
            IAmazonProductService amazonService,
            INotificationService notificationService)
        {
            _trackedProductsRepository = trackedProductsRepository;
            _userTrackedRepository = userTrackedRepository;
            _amazonService = amazonService;
            _notificationService = notificationService;
        }

        public async Task ExecuteAsync()
        {
            var products = await _trackedProductsRepository.GetAllAsync();

            foreach (var product in products)
            {
                var updatedData = await _amazonService.GetProductDetailsAsync(product.url);

                product.CurrentPrice = updatedData.Price;
                product.PriceSaving = updatedData.PriceSaving;
                product.ProductRating = updatedData.ProductRating;

                // 🕓 LastFetchTime'ı şimdiye güncelle
                product.LastFetchTime = DateTime.Now;

                _trackedProductsRepository.UpdateAsync(product);

                if (updatedData.PriceSaving!=null) // if(updatedData.IsDiscounted) gibi bir sey daha iyi olabilir mi
                {
                    var userLinks = await _userTrackedRepository.GetListGetWhere(x => x.TrackedProductId == product.Id);

                    foreach (var link in userLinks)
                    {
                        var notification = new Notification
                        {
                            UserId = link.UserId,
                            Message = $"{product.ProductTitle} is now discounted!",
                            CreatedAt = DateTime.Now
                        };

                        await _notificationService.CreateAsync(notification);
                    }
                }
            }
        }

    }

}

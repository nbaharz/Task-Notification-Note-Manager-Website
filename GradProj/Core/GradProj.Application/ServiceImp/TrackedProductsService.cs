using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GradProj.Application.ServiceAbs;
using GradProj.Domain.Entities;
using GradProj.Domain.RepositoryAbs;

namespace GradProj.Application.ServiceImp
{
    public class TrackedProductsService : GenericService<TrackedProducts>, ITrackedProductsService
    {
        private readonly ITrackedProductsRepository _trackedProductsRepository;
        public TrackedProductsService(ITrackedProductsRepository trackedProductsRepository) : base(trackedProductsRepository)
        {
            _trackedProductsRepository = trackedProductsRepository;
        }
    }
}

using GradProj.Application.ServiceAbs;
using GradProj.Infrastructure.External_Services.Amazon;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradProj.Infrastructure.External_Services.DI
{
    
    
         public static class ExternalDI
    {
        public static void Init(IServiceCollection services)
        {           
                      

            services.AddScoped<IAmazonProductService,AmazonProductService>();
           


            
        }
    }
    }


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BuWanluWeb._2_Service.Service;
using BuWanluWeb._2_Service.Service.Interface;

namespace BuWanluWeb._2_Service
{
    public class ServiceDepedencyProfile
    {
        public static void Register(IConfiguration configuration, IServiceCollection services)
        {
            services.AddScoped<IPenjualanService, PenjualanService>();
            services.AddScoped<IPelangganService, PelangganService>();
            services.AddScoped<IPakaianService, PakaianService>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BuWanluWeb._3_Data.Data;
using BuWanluWeb._3_Data.Data.Interface;

namespace BuWanluWeb._3_Data
{
    public class DataDepedencyProfile
    {
        public static void Register(IConfiguration configuration, IServiceCollection services)
        {
            services.AddScoped<IPenjualanRepository, PenjualanRepository>();
            services.AddScoped<IPakaianRepository, PakaianRepository>();
            services.AddScoped<IPelangganRepository, PelangganRepository>();
        }
    }
}

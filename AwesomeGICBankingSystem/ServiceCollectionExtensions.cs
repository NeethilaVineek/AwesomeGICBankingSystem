using AwesomeGICBankingSystem.Application;
using AwesomeGICBankingSystem.Core;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeGICBankingSystem
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAppDI(this IServiceCollection services)
        {
            services.AddApplicationDI()
                .AddCoreDI();
            services.AddTransient<BankService>();
            return services; 
        }
    }
}

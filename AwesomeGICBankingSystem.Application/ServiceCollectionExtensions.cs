using AwesomeGICBankingSystem.Application.Validator;
using Microsoft.Extensions.DependencyInjection;

namespace AwesomeGICBankingSystem.Application
{
    public static class ServiceCollectionExtensions 
    {
        public static IServiceCollection AddApplicationDI(this IServiceCollection services)
        {
            return services;
        }
    }
}

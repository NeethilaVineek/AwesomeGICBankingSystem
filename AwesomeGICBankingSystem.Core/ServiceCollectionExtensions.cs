using Microsoft.Extensions.DependencyInjection;

namespace AwesomeGICBankingSystem.Core
{
    public static class ServiceCollectionExtensions 
    {
        public static IServiceCollection AddCoreDI(this IServiceCollection services)
        {
            return services; 
        }
    }
}

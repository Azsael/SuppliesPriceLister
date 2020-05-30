using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SuppliesPriceLister.Core.Loaders;
using SuppliesPriceLister.Core.Processors;

namespace SuppliesPriceLister.Core.Ioc
{
    public static class SuppliesPriceListerCoreBindings
    {
        public static IServiceCollection ConfigureSuppliesPriceListerCoreBindings(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .AddSingleton<IPriceListProcessor, PriceListProcessor>();
                //.AddSingleton<ISupplyListLoader, PriceListProcessor>()
                //.AddSingleton<ISupplyListProcessor, PriceListProcessor>();
        }
    }
}

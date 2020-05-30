using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SuppliesPriceLister.Core.Exchanger;
using SuppliesPriceLister.Core.Loaders;
using SuppliesPriceLister.Core.Loaders.Csv;
using SuppliesPriceLister.Core.Loaders.Json;
using SuppliesPriceLister.Core.Processors;

[assembly: InternalsVisibleTo("SuppliesPriceLister.Core.Tests")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]

namespace SuppliesPriceLister.Core.Ioc
{
    public static class SuppliesPriceListerCoreBindings
    {
        public static IServiceCollection ConfigureSuppliesPriceListerCoreBindings(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .AddOptions()
                .Configure<CurrencyConfig>(configuration.GetSection("Currency"))
                .AddSingleton<IPriceListProcessor, PriceListProcessor>()
                .AddSingleton<IList<ISupplyListParser>>(x => x.GetServices<ISupplyListParser>().ToList())
                .AddSingleton<ISupplyListParser, JsonSupplyListParser>()
                .AddSingleton<ISupplyListParser, CsvSupplyListParser>()
                .AddSingleton<ISupplyListProcessor, SupplyListProcessor>()
                .AddSingleton<ICurrencyConverter, ExtremelyLimitedCurrencyConverter>();
        }
    }
}

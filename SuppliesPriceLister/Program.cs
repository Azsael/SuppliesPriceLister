using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.Extensions.Logging;
using SuppliesPriceLister.Core;
using SuppliesPriceLister.Core.Ioc;
using SuppliesPriceLister.Core.Models;

namespace SuppliesPriceLister
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync(args).Wait();
        }

        static async Task MainAsync(string[] args)
        {
            var env = CreateHostingEnvironment();
            var configuration = CreateConfiguration(env);
            var serviceProvider = new ServiceCollection()
                .AddLogging(opt => opt.AddConsole())
                .AddSingleton(configuration)
                .ConfigureSuppliesPriceListerCoreBindings(configuration)
                .BuildServiceProvider();

            var files = new[] 
            {
                new SupplyList
                {
                    FilePath = $"{Directory.GetCurrentDirectory()}humphries.csv",
                    Currency = "AUD",
                    Format = "csv"
                },
                new SupplyList
                {
                    FilePath = $"{Directory.GetCurrentDirectory()}megacorp.json",
                    Currency = "USD",
                    Format = "json"
                }
            };
            
            var processor = serviceProvider.GetService<IPriceListProcessor>();

            await processor.ProcessSupplyList(files);
        }

        private static IHostEnvironment CreateHostingEnvironment()
        {
            return new HostingEnvironment
            {
                EnvironmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"),
                ApplicationName = AppDomain.CurrentDomain.FriendlyName,
                ContentRootPath = AppDomain.CurrentDomain.BaseDirectory,
                ContentRootFileProvider = new PhysicalFileProvider(AppDomain.CurrentDomain.BaseDirectory)
            };
        }

        private static IConfiguration CreateConfiguration(IHostEnvironment env)
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddEnvironmentVariables()
                .AddJsonFile("appsettings.json", optional: false)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .Build();
        }
    }
}

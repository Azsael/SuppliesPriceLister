using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using SuppliesPriceLister.Common;
using SuppliesPriceLister.Core.Exchanger;
using SuppliesPriceLister.Core.Ioc;
using SuppliesPriceLister.Core.Models;

namespace SuppliesPriceLister.Core.Processors
{
    internal class SupplyListProcessor : ISupplyListProcessor
    {
        private readonly ICurrencyConverter _converter;
        private readonly string _desiredCurrency;

        public SupplyListProcessor(ICurrencyConverter converter, IOptions<CurrencyConfig> config)
        {
            _converter = converter;
            _desiredCurrency = config.Value.DesiredCurrency;
        }

        public async Task ProcessSupplyList(IList<SupplyListItem> supplyItems)
        {
            (await supplyItems.Select(async x => new
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = await _converter.ConvertCurrency(x.Price, x.Currency, _desiredCurrency)
                })
                .WhenAll())
                .OrderByDescending(x => x.Price)
                .Select(x => $"{x.Id}, {x.Name}, {FormatPrice(x.Price)}\r\n")
                .ForEach(Console.WriteLine);
        }

        private string FormatPrice(decimal price)
        {
            // convert to nearest cent (round) 🤑
            return Math.Round(price, 2).ToString("C2");
        }
    }
}
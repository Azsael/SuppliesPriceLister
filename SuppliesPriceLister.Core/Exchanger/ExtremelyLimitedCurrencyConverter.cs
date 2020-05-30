using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using SuppliesPriceLister.Core.Ioc;

namespace SuppliesPriceLister.Core.Exchanger
{
    internal class ExtremelyLimitedCurrencyConverter : ICurrencyConverter
    {
        private readonly decimal _usdToAuExchangeRate;

        public ExtremelyLimitedCurrencyConverter(IOptions<CurrencyConfig> config)
        {
            _usdToAuExchangeRate = config.Value.AudUsdExchangeRate;
        }

        public Task<decimal> ConvertCurrency(decimal value, string fromCurrency, string toCurrency)
        {
            if (fromCurrency == toCurrency)
                return Task.FromResult(value);

            if (fromCurrency == "USD" && toCurrency == "AUD")
                return Task.FromResult(value * _usdToAuExchangeRate);
            
            throw new ArgumentException("Can only perform USD to AUD conversions 😥");
        }
    }
}
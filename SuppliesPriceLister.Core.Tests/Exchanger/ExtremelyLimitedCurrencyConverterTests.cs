using System;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Extensions.Options;
using SuppliesPriceLister.Core.Exchanger;
using SuppliesPriceLister.Core.Ioc;
using Xunit;

namespace SuppliesPriceLister.Core.Tests.Exchanger
{
    public class ExtremelyLimitedCurrencyConverterTests
    {
        [Fact]
        public async Task GivenConvertCurrency_WhenCurrenciesAreSame_ThenNoConversionHappens()
        {
            var options = new OptionsWrapper<CurrencyConfig>(new CurrencyConfig { AudUsdExchangeRate = 10 });
            var convert = new ExtremelyLimitedCurrencyConverter(options);

            var currency = await convert.ConvertCurrency(10.3m, "AUD", "AUD");

            currency.Should().Be(10.3m);

            currency = await convert.ConvertCurrency(323.53m, "CAD", "CAD");

            currency.Should().Be(323.53m);

            currency = await convert.ConvertCurrency(210.3m, "USD", "USD");

            currency.Should().Be(210.3m);
        }

        [Fact]
        public async Task GivenConvertCurrency_WhenCurrencyFromIsAUDAndToIsUSD_ThenConversionHappens()
        {
            var options = new OptionsWrapper<CurrencyConfig>(new CurrencyConfig { AudUsdExchangeRate = 10 });
            var convert = new ExtremelyLimitedCurrencyConverter(options);
            
            var currency = await convert.ConvertCurrency(10.3m, "USD", "AUD");

            currency.Should().Be(103.0m);

            currency = await convert.ConvertCurrency(33.12m, "USD", "AUD");

            currency.Should().Be(331.2m);

            options = new OptionsWrapper<CurrencyConfig>(new CurrencyConfig { AudUsdExchangeRate = 5 });
            convert = new ExtremelyLimitedCurrencyConverter(options);

            currency = await convert.ConvertCurrency(5m, "USD", "AUD");

            currency.Should().Be(25m);
        }

        [Fact]
        public async Task GivenConvertCurrency_WhenCurrencyIsNotAudToUSD_ThenArgumentExceptionExplosion()
        {
            var options = new OptionsWrapper<CurrencyConfig>(new CurrencyConfig { AudUsdExchangeRate = 10 });
            var convert = new ExtremelyLimitedCurrencyConverter(options);

            await convert.Invoking(async y => await y.ConvertCurrency(10.3m, "CAD", "AUD"))
                .Should().ThrowAsync<ArgumentException>()
                .WithMessage("Can only perform USD to AUD conversions 😥");

            await convert.Invoking(async y => await y.ConvertCurrency(10.3m, "AUD", "USD"))
                .Should().ThrowAsync<ArgumentException>()
                .WithMessage("Can only perform USD to AUD conversions 😥");

            await convert.Invoking(async y => await y.ConvertCurrency(10.3m, "CAD", "USD"))
                .Should().ThrowAsync<ArgumentException>()
                .WithMessage("Can only perform USD to AUD conversions 😥");
        }
    }
}

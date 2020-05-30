using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SuppliesPriceLister.Core.Exchanger
{
    public interface ICurrencyConverter
    {
        Task<decimal> ConvertCurrency(decimal value, string fromCurrency, string toCurrency);
    }
}

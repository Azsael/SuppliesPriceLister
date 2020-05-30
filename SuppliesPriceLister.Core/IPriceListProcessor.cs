using System.Collections.Generic;
using System.Threading.Tasks;
using SuppliesPriceLister.Core.Models;

namespace SuppliesPriceLister.Core
{
    public interface IPriceListProcessor
    {
        Task ProcessSupplyList(IList<SupplyList> supplyLists);
    }
}


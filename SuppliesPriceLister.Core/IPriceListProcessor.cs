using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuppliesPriceLister.Core
{
    public interface IPriceListProcessor
    {
        Task ProcessSupplyList(IList<SupplyList> supplyLists);
    }
}


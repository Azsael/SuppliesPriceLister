using System.Collections.Generic;
using System.Threading.Tasks;
using SuppliesPriceLister.Core.Models;

namespace SuppliesPriceLister.Core.Loaders
{
    public interface ISupplyListParser
    {
        bool CanLoad(SupplyList list);

        Task<IList<SupplyListItem>> LoadSupplyList(SupplyList list);
    }
}
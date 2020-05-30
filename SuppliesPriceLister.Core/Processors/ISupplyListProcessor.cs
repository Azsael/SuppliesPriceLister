using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SuppliesPriceLister.Core.Models;

namespace SuppliesPriceLister.Core.Processors
{
    public interface ISupplyListProcessor
    {
        Task ProcessSupplyList(IList<SupplyListItem> supplyItems);
    }
}

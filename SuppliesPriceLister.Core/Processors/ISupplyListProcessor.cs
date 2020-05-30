using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SuppliesPriceLister.Core.Models;

namespace SuppliesPriceLister.Core.Processors
{
    public interface ISupplyListProcessor
    {
        Task ProcessSuppyList(IList<SupplyListItem> supplyItems);
    }
}

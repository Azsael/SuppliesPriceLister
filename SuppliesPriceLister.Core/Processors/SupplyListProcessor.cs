using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SuppliesPriceLister.Core.Models;

namespace SuppliesPriceLister.Core.Processors
{
    internal class SupplyListProcessor : ISupplyListProcessor
    {
        public Task ProcessSupplyList(IList<SupplyListItem> supplyItems)
        {
            throw new NotImplementedException();
        }
    }
}
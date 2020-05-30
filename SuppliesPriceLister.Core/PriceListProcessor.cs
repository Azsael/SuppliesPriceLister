using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SuppliesPriceLister.Common;
using SuppliesPriceLister.Core.Loaders;
using SuppliesPriceLister.Core.Models;
using SuppliesPriceLister.Core.Processors;

namespace SuppliesPriceLister.Core
{
    internal class PriceListProcessor : IPriceListProcessor
    {
        private readonly IList<ISupplyListParser> _loaders;
        private readonly ISupplyListProcessor _processor;

        public PriceListProcessor(IList<ISupplyListParser> loaders, ISupplyListProcessor processor)
        {
            _loaders = loaders;
            _processor = processor;
        }

        public async Task ProcessSupplyList(IList<SupplyList> supplyLists)
        {
            var supplyList = (await supplyLists.Select(LoadSupplyList).WhenAll())
                .SelectMany(x => x)
                .ToList();

            await _processor.ProcessSupplyList(supplyList);
        }

        private Task<IList<SupplyListItem>> LoadSupplyList(SupplyList supplyList)
        {
            var loader = _loaders.FirstOrDefault(x => x.CanLoad(supplyList));

            if (loader != null)
            {
                return loader.LoadSupplyList(supplyList);
            }
            throw new ArgumentOutOfRangeException(nameof(supplyList), "Invalid Supply List");
        }
    }
}
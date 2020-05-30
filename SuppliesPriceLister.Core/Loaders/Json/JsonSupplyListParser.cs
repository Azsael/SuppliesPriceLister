using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SuppliesPriceLister.Core.Models;

namespace SuppliesPriceLister.Core.Loaders.Json
{
    internal class JsonSupplyListParser : ISupplyListParser
    {
        public bool CanLoad(SupplyList list) => list.Format == "json";

        public async Task<IList<SupplyListItem>> LoadSupplyList(SupplyList list)
        {
            var contents = await File.ReadAllTextAsync(list.FilePath);
            
            var supplyList = JsonConvert.DeserializeObject<SupplyListJsonFile>(contents);

            return supplyList.Partners
                .SelectMany(x => x.Supplies)
                .Select(x => new SupplyListItem
                {
                    Id = x.Id,
                    Name = x.Description,
                    Unit = x.Uom,
                    Price = x.priceInCents / 100m,
                    MaterialType = x.MaterialType,
                    Currency = list.Currency
                })
                .ToList();
        }
    }
}
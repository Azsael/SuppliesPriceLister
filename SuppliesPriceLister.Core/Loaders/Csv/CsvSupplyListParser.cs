using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using CsvHelper;
using SuppliesPriceLister.Core.Models;

namespace SuppliesPriceLister.Core.Loaders.Csv
{
    internal class CsvSupplyListParser : ISupplyListParser
    {
        public bool CanLoad(SupplyList list) => list.Format == "csv";

        public async Task<IList<SupplyListItem>> LoadSupplyList(SupplyList list)
        {
            await using var fileStream = File.OpenRead(list.FilePath);
            using var reader = new StreamReader(fileStream);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

            var supplyListItems = new List<SupplyListItem>();

            await foreach(var row in csv.GetRecordsAsync<SupplyListCsvRow>())
            {
                supplyListItems.Add(new SupplyListItem
                {
                    Id = row.Id,
                    Name = row.Name,
                    Price = row.Price,
                    Currency = list.Currency
                });
            }

            return supplyListItems;
        }
    }
}
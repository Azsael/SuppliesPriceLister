using CsvHelper.Configuration.Attributes;

namespace SuppliesPriceLister.Core.Loaders.Csv
{
    internal class SupplyListCsvRow
    {
        [Name("identifier")]
        public string Id { get; set; }
        [Name("desc")]
        public string Name { get; set; }
        [Name("unit")]
        public string Unit { get; set; }
        [Name("costAUD")]
        public decimal Price { get; set; }
    }
}
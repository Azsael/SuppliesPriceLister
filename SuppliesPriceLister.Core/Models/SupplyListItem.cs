namespace SuppliesPriceLister.Core.Models
{
    public class SupplyListItem
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Unit { get; set; }

        public decimal Price { get; set; }

        public string MaterialType { get; set; }
        public string ProviderId { get; set; }

    }
}
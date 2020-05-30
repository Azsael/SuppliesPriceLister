namespace SuppliesPriceLister.Core.Loaders.Json
{
    internal class SupplyListJsonItem
    {
        public string Id { get; set; }

        public string Description { get; set; }

        public string Uom { get; set; }

        public int priceInCents { get; set; }
        
        public string MaterialType { get; set; }
        public string ProviderId { get; set; }
    }
}
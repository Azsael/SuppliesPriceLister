using System.Collections.Generic;

namespace SuppliesPriceLister.Core.Loaders.Json
{
    internal class SupplyListJsonFilePartner
    {
        public string Name { get; set; }
        public string PartnerType { get; set; }
        public string PartnerAddress { get; set; }
        public IList<SupplyListJsonItem> Supplies { get; set; }

    }
}
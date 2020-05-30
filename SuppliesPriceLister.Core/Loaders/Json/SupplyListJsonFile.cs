using System.Collections.Generic;

namespace SuppliesPriceLister.Core.Loaders.Json
{
    internal class SupplyListJsonFile
    {
        public IList<SupplyListJsonFilePartner> Partners { get; set; }
    }
}
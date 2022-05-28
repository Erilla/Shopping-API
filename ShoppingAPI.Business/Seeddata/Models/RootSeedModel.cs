using Newtonsoft.Json;

namespace ShoppingAPI.Business.Seeddata.Models
{
    public class RootSeedModel
    {
        [JsonProperty("products")]
        public List<ProductSeedModel> Products { get; set; }

        [JsonProperty("specificPrices")]
        public List<SpecificPriceSeedModel> SpecificPrices { get; set; }
    }
}

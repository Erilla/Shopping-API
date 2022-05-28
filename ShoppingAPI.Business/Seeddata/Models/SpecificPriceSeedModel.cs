using Newtonsoft.Json;

namespace ShoppingAPI.Business.Seeddata.Models
{
    public class SpecificPriceSeedModel
    {
        [JsonProperty("customer")]
        public string Customer { get; set; }

        [JsonProperty("products")]
        public List<ProductSeedModel> Products { get; set; }
    }
}

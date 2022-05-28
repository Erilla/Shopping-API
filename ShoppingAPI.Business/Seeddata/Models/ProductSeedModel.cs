using Newtonsoft.Json;

namespace ShoppingAPI.Business.Seeddata.Models
{
    public class ProductSeedModel
    {
        [JsonProperty("ean")]
        public string ProductCode { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }
    }
}

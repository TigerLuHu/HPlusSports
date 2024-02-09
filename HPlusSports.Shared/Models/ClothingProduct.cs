using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HPlusSports.Shared.Models
{
    public class ClothingProduct : ProductBase
    {
        [JsonProperty(ItemConverterType = typeof(StringEnumConverter))]
        public SizeType[] Sizes { get; set; }
        public override string Category { get; } = Categories.Clothing;
    }
}

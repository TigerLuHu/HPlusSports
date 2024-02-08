using HPlusSports.Shared.Cosmos.Attributes;

using JsonSubTypes;

using Newtonsoft.Json;

namespace HPlusSports.Shared.Models
{
    [CosmosContainerName("Product")]
    [JsonConverter(typeof(JsonSubtypes), nameof(Category))]
    [JsonSubtypes.KnownSubType(typeof(ClothingProduct), Categories.Clothing)]
    [JsonSubtypes.KnownSubType(typeof(NutritionalProduct), Categories.Nutritional)]
    public abstract class ProductBase : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public string ImageTitle { get; set; }

        public string Image { get; set; }

        public abstract string Category { get; }
    }
}

using Newtonsoft.Json;

namespace HPlusSports.Functions.Models
{
    public abstract class EntityBase
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
    }
}

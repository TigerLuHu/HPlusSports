using Newtonsoft.Json;

namespace HPlusSports.Functions.InProcess.Models
{
    public abstract class EntityBase
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
    }
}

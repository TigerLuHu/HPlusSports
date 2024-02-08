﻿using Newtonsoft.Json;

namespace HPlusSports.Shared.Models
{
    public abstract class EntityBase
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
    }
}

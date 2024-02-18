namespace HPlusSports.Shared.Cosmos
{
    // CAUTION: The Cosmos repository is designed to support multiple databases, but this [CosmosDBOptions] need to be refactored.
    public class CosmosDBOptions
    {
        public string Endpoint { get; set; }

        public string Key { get; set; }

        public string Database { get; set; }
    }
}

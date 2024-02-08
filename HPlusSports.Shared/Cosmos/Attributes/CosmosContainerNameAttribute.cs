namespace HPlusSports.Shared.Cosmos.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class CosmosContainerNameAttribute : Attribute
    {
        public CosmosContainerNameAttribute(string containerName) 
        {
            ContainerName = containerName;
        }

        public string ContainerName { get; set; }
    }
}

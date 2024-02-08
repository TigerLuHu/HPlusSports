using HPlusSports.Shared.Cosmos.Attributes;

using System.Collections.Concurrent;

namespace HPlusSports.Shared.Cosmos
{
    public class ContainerNameResolver : IContainerNameResolver
    {
        private readonly ConcurrentDictionary<Type, string> _containerNameCache = new ConcurrentDictionary<Type, string>();

        public string Resolve<T>()
        {
            var type = typeof(T);

            if (_containerNameCache.TryGetValue(type, out string containerName))
            {
                return containerName;
            }

            containerName = ResolveContainerName(type);
            _containerNameCache.TryAdd(type, containerName);

            return containerName;
        }

        protected virtual string ResolveContainerName(Type type)
        {
            var cosmosContainerNameAttribute = type.GetCustomAttributes(typeof(CosmosContainerNameAttribute), true).FirstOrDefault() as CosmosContainerNameAttribute;
            return cosmosContainerNameAttribute?.ContainerName ?? type.Name;
        }
    }
}

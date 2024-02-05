using System.Collections.Concurrent;

namespace HPlusSports.Shared.Cosmos
{
    public class ContainerNameResolver : IContainerNameResolver
    {
        private readonly ConcurrentDictionary<Type, string> _containerNameCache = new ConcurrentDictionary<Type, string>();

        public string Resolve<T>()
        {
            var type = typeof(T);
            if (_containerNameCache.TryGetValue(type, out string name))
            {
                return name;
            }

            var containerName = ResolveContainerName(type);
            _containerNameCache.TryAdd(type, containerName);

            return containerName;
        }

        private string ResolveContainerName(Type type)
        {
            return type.Name;
        }
    }
}

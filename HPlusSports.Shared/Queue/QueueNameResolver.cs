using HPlusSports.Shared.Queue.Attributes;

using System.Collections.Concurrent;

namespace HPlusSports.Shared.Queue
{
    public class QueueNameResolver : IQueueNameResolver
    {
        private ConcurrentDictionary<Type, string> _queueNameCache = new ConcurrentDictionary<Type, string>();

        public string Resolve<T>()
        {
            var type = typeof(T);

            return _queueNameCache.GetOrAdd(type, ResolveQueueName(type));
        }

        protected virtual string ResolveQueueName(Type type)
        {
            var azureQueueNameAttribute = type.GetCustomAttributes(typeof(AzureQueueNameAttribute), true).FirstOrDefault() as AzureQueueNameAttribute;
            return azureQueueNameAttribute?.QueueName ?? type.Name;
        }
    }
}

using HPlusSports.Shared.Table.Attributes;

using System.Collections.Concurrent;

namespace HPlusSports.Shared.Table
{
    public class TableNameResolver : ITableNameResolver
    {
        private ConcurrentDictionary<Type, string> _tableNameCache = new ConcurrentDictionary<Type, string>();

        public string Resolve<T>()
        {
            var type = typeof(T);

            return _tableNameCache.GetOrAdd(type, ResolveTableName(type));
        }

        protected virtual string ResolveTableName(Type type)
        {
            var azureTableNameAttribute = type.GetCustomAttributes(typeof(AzureTableNameAttribute), true).FirstOrDefault() as AzureTableNameAttribute;
            return azureTableNameAttribute?.TableName ?? type.Name;
        }
    }
}

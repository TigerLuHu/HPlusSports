namespace HPlusSports.Shared.Table
{
    public interface ITableNameResolver
    {
        string Resolve<T>();
    }
}

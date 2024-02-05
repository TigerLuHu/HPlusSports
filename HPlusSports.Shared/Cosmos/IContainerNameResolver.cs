namespace HPlusSports.Shared.Cosmos
{
    public interface IContainerNameResolver
    {
        string Resolve<T>();
    }
}

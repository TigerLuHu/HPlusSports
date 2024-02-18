namespace HPlusSports.Shared.Queue
{
    public interface IQueueNameResolver
    {
        string Resolve<T>();
    }
}

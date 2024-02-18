namespace HPlusSports.Shared.Queue.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class AzureQueueNameAttribute : Attribute
    {
        public AzureQueueNameAttribute(string queueName)
        {
            QueueName = queueName;
        }

        public string QueueName { get; set; }
    }
}

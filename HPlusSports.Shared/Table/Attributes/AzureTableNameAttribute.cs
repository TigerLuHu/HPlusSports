namespace HPlusSports.Shared.Table.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class AzureTableNameAttribute : Attribute
    {
        public AzureTableNameAttribute(string tableName) 
        {
            TableName = tableName;
        }

        public string TableName { get; set; }
    }
}

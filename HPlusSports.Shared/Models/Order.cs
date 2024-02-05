namespace HPlusSports.Shared.Models
{
    public class Order : EntityBase
    {
        public List<OrderItem> Items { get; set; }
    }
}

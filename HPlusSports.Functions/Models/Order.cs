using System.Collections.Generic;

namespace HPlusSports.Functions.Models
{
    public class Order : EntityBase
    {
        public List<OrderItem> Items { get; set; }
    }
}

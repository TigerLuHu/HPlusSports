using System.Collections.Generic;

namespace HPlusSports.Functions.Isolated.Models
{
    public class Order : EntityBase
    {
        public List<OrderItem> Items { get; set; }
    }
}

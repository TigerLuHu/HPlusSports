using System.Collections.Generic;

namespace HPlusSports.Functions.InProcess.Models
{
    public class Order : EntityBase
    {
        public List<OrderItem> Items { get; set; }
    }
}

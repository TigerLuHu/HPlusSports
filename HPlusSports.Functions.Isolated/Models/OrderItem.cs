using Newtonsoft.Json;

namespace HPlusSports.Functions.Isolated.Models
{
    public class OrderItem : EntityBase
    {
        public string Name { get; set; }

        public string Category { get; set; }

        public long Quantity { get; set; }

        public string Size { get; set; }
    }
}

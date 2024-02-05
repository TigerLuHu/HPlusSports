namespace HPlusSports.Shared.Models
{
    public class ProductBase : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public string ImageTitle { get; set; }

        public string Image { get; set; }

        public string Category { get; set; }
    }
}

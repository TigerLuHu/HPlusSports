namespace HPlusSports.Shared.Models
{
    public class ClothingProduct : ProductBase
    {
        public string[] Sizes { get; set; }
        public override string Category { get; } = Categories.Clothing;
    }
}

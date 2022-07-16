namespace ProductsApp.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ReleaseDate { get; set; }
        public float OriginalPrice { get; set; }
        public float Discount { get; set; }
        public string PictureUrl { get; set; }
    }
}

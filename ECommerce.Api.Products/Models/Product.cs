namespace ECommerce.Api.Products.Models
{
    public class Product//This is the one that we are going to return from the provider
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Inventory { get; set; }
    }
}

namespace ErickEspinosa.Redis.WebApi.Data
{
    public class Product{
        public Product(string name, decimal price)
        {
            Id = Guid.NewGuid();
            Name = name;
            Price = price;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
    }
    public static class FakeRepository
    {

        public static IEnumerable<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product("Book", 29.9m),
                new Product("Pencil", 39.9m),
                new Product("Screwdriver", 9.9m),
            };
        }
    }
}

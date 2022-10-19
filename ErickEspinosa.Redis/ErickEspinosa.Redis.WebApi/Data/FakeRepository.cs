namespace ErickEspinosa.Redis.WebApi.Data
{
    public class Product{
        public Product(Guid id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
    }
    public static class FakeRepository
    {
        private static List<Product> _products = new List<Product>
        {
            new Product(new Guid("c8cbd9eb-fe3c-4335-9ecc-c05d1b93afe4"), "Book", 29.9m),
            new Product(new Guid("da705f13-d162-4ad0-85b9-c7af7c3ee174"), "Pencil", 39.9m),
            new Product(new Guid("8d1d045a-083e-4fc5-9aa9-693c5b0677a0"), "Screwdriver", 9.9m),
        };

        public static IEnumerable<Product> GetProducts() => _products;
        public static Product GetProduct(Guid id) => _products.FirstOrDefault(x=> x.Id == id);
    }
}

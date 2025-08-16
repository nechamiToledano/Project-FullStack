namespace MyProject.Domain.Entities;

public class Product
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public decimal Price { get; private set; }

    public Product(string name, decimal price)
    {
        Id = Guid.NewGuid();
        Name = name;
        Price = price;
    }

    // דוגמא לפעולה דומיינית
    public void UpdatePrice(decimal newPrice)
    {
        if (newPrice <= 0) throw new ArgumentException("Price must be > 0");
        Price = newPrice;
    }
}
namespace inventory_api.Domain.Entities;

public class ProductBO
{
  public long? Id { get; private set; }
  public string Name { get; private set; }
  public string Description { get; private set; }
  public decimal Price { get; private set; }
  public int Quantity { get; private set; }
  public string ImageURL { get; private set; }
  public SupplierBO Supplier { get; private set; }

  public ProductBO(long? id, string name, string description, decimal price, int quantity, string imageUrl, SupplierBO supplier)
  {
    Id = id;
    Name = name;
    Description = description;
    Price = price;
    Quantity = quantity;
    ImageURL = imageUrl;
    Supplier = supplier;
  }

  public void Validate()
  {
    if (string.IsNullOrWhiteSpace(Name))
    {
      throw new ArgumentException("Product name is required");
    }
  }

}
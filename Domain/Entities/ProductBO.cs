using InventoryApi.Domain.Assertions;

namespace InventoryApi.Domain.Entities;

public class ProductBO
{
    public long? Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }
    public int Quantity { get; private set; }

    public string ImageURL { get; private set; }

    // public HashSet<ProductAttributeBO> Attributes { get; private set; }
    public SupplierBO Supplier { get; private set; }

    public ProductBO(long? id, string name, string description, decimal price, int quantity, string imageUrl,
        SupplierBO supplier)
    {
        Id = id;
        Name = name;
        Description = description;
        Price = price;
        Quantity = quantity;
        ImageURL = imageUrl;
        Supplier = supplier;

        Validate();
    }

    public void Validate()
    {
        Assert.IsNullOrWhiteSpace(Name, "Product name is required");
        Assert.IsGreaterThan(Price, 0, "Product price must be greater than zero");
        Assert.IsGreaterThanOrEqual(Quantity, 0, "Product quantity must be greater than or equal to zero");
        Assert.IsHttpUrl(ImageURL, "Product image URL is invalid");
    }
}
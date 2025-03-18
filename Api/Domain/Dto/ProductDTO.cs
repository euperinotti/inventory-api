namespace InventoryApi.Domain.Dto.Request;

public record ProductDTO
{
    public long? Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public string ImageURL { get; set; }
    // public HashSet<ProductAttributeBO> Attributes { get; set; }
    public long SupplierId { get; set; }
    public SupplierDTO Supplier { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}

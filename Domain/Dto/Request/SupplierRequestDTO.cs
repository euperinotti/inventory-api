namespace InventoryApi.Domain.Dto.Request;

public record SupplierRequestDTO
{
    public long? Id { get; set; }
    public string Name { get; set; }
    public string Cnpj { get; set; }
    public string Address { get; set; }
    public string Contact { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
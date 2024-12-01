namespace inventory_api.Presentation.Dtos.Supplier;

public class SupplierResponseDTO
{
    public long? Id { get; set; }
    public string? Name { get; set; }
    public string? Cnpj { get; set; }
    public string? Address { get; set; }
    public string? Contact { get; set; }
}
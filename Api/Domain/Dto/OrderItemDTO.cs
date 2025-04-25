namespace Api.Domain.Dto.Request;

public record OrderItemDTO
{
    public long? Id { get; set; }
    public long? ProductId { get; set; }
    public ProductDTO Product { get; set; }
    public OrderDTO Order { get; set; }
    public long? OrderId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}

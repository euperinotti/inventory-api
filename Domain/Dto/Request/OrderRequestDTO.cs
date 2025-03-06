namespace InventoryApi.Domain.Dto.Request;

public record OrderRequestDTO
{
    public long? Id { get; set; }
    public DateTime Date { get; set; }
    public OrderStatus Status { get; set; }
    public long SupplierId { get; set; }
    public List<OrderItemRequestDTO> Items { get; set; }
    public decimal Total { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}

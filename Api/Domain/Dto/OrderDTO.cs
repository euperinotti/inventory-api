using Api.Domain.Enums;

namespace Api.Domain.Dto.Request;

public record OrderDTO
{
    public long? Id { get; set; }
    public DateTime Date { get; set; }
    public OrderStatus Status { get; set; }
    public SupplierDTO Supplier { get; set; }
    public List<OrderItemDTO> Items { get; set; }
    public decimal Total { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}

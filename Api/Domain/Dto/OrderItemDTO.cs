﻿namespace InventoryApi.Domain.Dto.Request;

public record OrderItemDTO
{
    public long? Id { get; set; }
    public long ProductId { get; set; }
    public long OrderId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}

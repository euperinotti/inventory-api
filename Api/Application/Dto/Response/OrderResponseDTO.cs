﻿using InventoryApi.Presentation.Dtos.Supplier;

namespace InventoryApi.Domain.Dto.Response;

public record OrderResponseDTO
{
    public long? Id { get; set; }
    public DateTime Date { get; set; }
    public OrderStatus Status { get; set; }
    public SupplierResponseDTO Supplier { get; set; }
    public decimal Total { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}

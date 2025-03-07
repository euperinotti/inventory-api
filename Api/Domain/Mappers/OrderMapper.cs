using InventoryApi.Domain.Dto.Request;
using InventoryApi.Domain.Dto.Response;
using InventoryApi.Domain.Entities;

namespace InventoryApi.Domain.Mappers;

public static class OrderMapper
{
    public static OrderResponseDTO ToDTO(OrderBO bo)
    {
        OrderResponseDTO dto = new OrderResponseDTO();
        dto.Id = bo.Id;
        dto.Date = bo.Date;
        dto.Status = bo.Status;
        dto.Total = bo.Total;
        dto.SupplierId = (long) bo.Supplier.Id;
        dto.CreatedAt = bo.CreatedAt;
        dto.UpdatedAt = bo.UpdatedAt;

        return dto;
    }

    public static OrderRequestDTO ToRequestDTO(OrderBO bo)
    {
        OrderRequestDTO dto = new OrderRequestDTO();
        dto.Id = bo.Id;
        dto.Date = bo.Date;
        dto.Status = bo.Status;
        dto.Total = bo.Total;
        dto.SupplierId = (long) bo.Supplier.Id;
        dto.CreatedAt = bo.CreatedAt;
        dto.UpdatedAt = bo.UpdatedAt;

        return dto;
    }

    public static OrderBO ToBO(OrderRequestDTO dto)
    {
        List<OrderItemBO> items = dto.Items.Select(OrderItemMapper.ToBO).ToList();
        return new OrderBO(dto.Id,
            dto.Date,
            dto.Status,
            items,
            dto.Total,
            null,
            dto.CreatedAt,
            dto.UpdatedAt);
    }
}

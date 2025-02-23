using InventoryApi.Domain.Entities;
using InventoryApi.Domain.Dto.Request;

namespace InventoryApi.Domain.Mappers;

public static class OrderMapper
{
    public static OrderRequestDTO ToDTO(OrderBO bo)
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
        return new OrderBO(dto.Id, dto.Date, dto.Status, dto.Total, null, dto.CreatedAt, dto.UpdatedAt);
    }
}
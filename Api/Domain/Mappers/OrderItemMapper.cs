using InventoryApi.Domain.Entities;
using InventoryApi.Domain.Dto.Request;
using InventoryApi.Domain.Dto.Response;

namespace InventoryApi.Domain.Mappers;

public static class OrderItemMapper
{
    public static OrderItemResponseDTO ToDTO(OrderItemBO bo)
    {
        OrderItemResponseDTO dto = new OrderItemResponseDTO();
        dto.Id = bo.Id;
        dto.ProductId = (long) bo.Product.Id;
        dto.OrderId = (long) bo.Order.Id;
        dto.Quantity = bo.Quantity;
        dto.UnitPrice = bo.UnitPrice;

        return dto;
    }

    public static OrderItemBO ToBO(OrderItemRequestDTO dto)
    {
        return new OrderItemBO(dto.Id, null, null, dto.Quantity, dto.UnitPrice);
    }
}

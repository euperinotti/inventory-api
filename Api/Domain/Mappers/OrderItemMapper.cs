using InventoryApi.Domain.Entities;
using InventoryApi.Domain.Dto.Request;

namespace InventoryApi.Domain.Mappers;

public static class OrderItemMapper
{
    public static OrderItemDTO ToDTO(OrderItemBO bo)
    {
        OrderItemDTO dto = new OrderItemDTO();
        dto.Id = bo.Id;
        dto.ProductId = (long) bo.Product.Id;
        dto.OrderId = (long) bo.Order.Id;
        dto.Quantity = bo.Quantity;
        dto.UnitPrice = bo.UnitPrice;

        return dto;
    }

    public static OrderItemBO ToBO(OrderItemDTO dto)
    {
        return new OrderItemBO(dto.Id, null, null, dto.Quantity, dto.UnitPrice);
    }
}

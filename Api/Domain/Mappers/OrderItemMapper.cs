using Api.Domain.Entities;
using Api.Domain.Dto.Request;

namespace Api.Domain.Mappers;

public static class OrderItemMapper
{
    public static OrderItemDTO ToDTO(OrderItemBO bo)
    {
        OrderItemDTO dto = new OrderItemDTO();
        dto.Id = bo.Id;
        dto.ProductId = bo.Product?.Id;
        dto.OrderId = bo.Order?.Id;
        dto.Quantity = bo.Quantity;
        dto.UnitPrice = bo.UnitPrice;

        return dto;
    }

    public static OrderItemBO ToBO(OrderItemDTO dto)
    {
        return new OrderItemBO(dto.Id, ProductMapper.ToBO(dto.Product), OrderMapper.ToBO(dto.Order), dto.Quantity, dto.UnitPrice);
    }
}

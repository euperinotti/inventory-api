using InventoryApi.Domain.Assertions;
using InventoryApi.Domain.Dto.Response;
using InventoryApi.Domain.Entities;
using InventoryApi.Domain.Mappers;
using InventoryApi.Domain.Repository;

namespace InventoryApi.Domain.UseCases.Order;

public class FindOrder
{
    private readonly IOrderRepository _orderRepository;

    public FindOrder(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public OrderResponseDTO Execute(long orderId)
    {
        OrderBO? bo = _orderRepository.FindById(orderId);
        Assert.IsNull(bo, "Order not found");

        return OrderMapper.ToDTO(bo);
    }
}

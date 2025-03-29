using Api.Domain.Assertions;
using Api.Domain.Dto.Request;
using Api.Domain.Entities;
using Api.Domain.Mappers;
using Api.Domain.Repository;

namespace Api.Domain.UseCases.Order;

public class FindOrder
{
    private readonly IOrderRepository _orderRepository;

    public FindOrder(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public OrderDTO Execute(long orderId)
    {
        OrderBO? bo = _orderRepository.FindById(orderId);
        Assert.IsNull(bo, "Order not found");

        return OrderMapper.ToDTO(bo);
    }
}

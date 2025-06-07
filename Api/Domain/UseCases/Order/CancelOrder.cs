using Api.Domain.Assertions;
using Api.Domain.Entities;
using Api.Domain.Repository;

namespace Api.Domain.UseCases.Order;

public class CancelOrder
{
    private readonly IOrderRepository _orderRepository;

    public CancelOrder(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public OrderBO Execute(long orderId)
    {
        OrderBO? order = _orderRepository.FindById(orderId);
        Assert.IsNotNull(order, "Order not found");

        order?.Cancel();

        return order!;
    }

}

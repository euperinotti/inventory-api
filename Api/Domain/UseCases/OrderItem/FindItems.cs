using Api.Domain.Dto.Request;
using Api.Domain.Entities;
using Api.Domain.Mappers;
using Api.Domain.Repository;
using Api.Domain.UseCases.Order;

namespace Api.Domain.UseCases.OrderItem;

public class FindItems
{
    private readonly IOrderItemRepository _repository;
    private readonly IOrderRepository _orderRepository;

    public FindItems(IOrderItemRepository repository, IOrderRepository orderRepository)
    {
        _repository = repository;
        _orderRepository = orderRepository;
    }

    public List<OrderItemDTO> Execute(long orderId)
    {
        FindOrder findOrder = new FindOrder(_orderRepository);
        findOrder.Execute(orderId);

        List<OrderItemBO> items = _repository.FindByOrderId(orderId);

        return items.Select(OrderItemMapper.ToDTO).ToList();
    }
}

using InventoryApi.Domain.Dto.Request;
using InventoryApi.Domain.Entities;
using InventoryApi.Domain.Mappers;
using InventoryApi.Domain.Repository;
using InventoryApi.Domain.UseCases.Order;

namespace InventoryApi.Domain.UseCases.OrderItem;

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

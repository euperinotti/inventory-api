using Api.Domain.Dto.Request;
using Api.Domain.Entities;
using Api.Domain.Mappers;
using Api.Domain.Repository;

namespace Api.Domain.UseCases.Order;

public class UpdateOrder
{
    private readonly IOrderRepository _orderRepository;

    public UpdateOrder(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public OrderDTO Execute(OrderDTO dto)
    {
        FindOrder findOrder = new FindOrder(_orderRepository);
        OrderDTO orderDto = findOrder.Execute((long) dto.Id!);

        OrderBO bo = OrderMapper.ToBO(orderDto);
        OrderBO newBO = OrderMapper.ToBO(dto);

        bo.UpdateOrder(newBO.Status, newBO.Items);
        bo.CalculateAmount();

        bo = _orderRepository.Update(bo);

        return OrderMapper.ToDTO(bo);
    }

}

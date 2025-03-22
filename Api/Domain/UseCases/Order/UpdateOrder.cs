using InventoryApi.Domain.Dto.Request;
using InventoryApi.Domain.Entities;
using InventoryApi.Domain.Mappers;
using InventoryApi.Domain.Repository;

namespace InventoryApi.Domain.UseCases.Order;

public class UpdateOrder
{
    private readonly IOrderRepository _orderRepository;
    private readonly ISupplierRepository _supplierRepository;

    public UpdateOrder(IOrderRepository orderRepository, ISupplierRepository supplierRepository)
    {
        _orderRepository = orderRepository;
        _supplierRepository = supplierRepository;
    }

    public OrderDTO Execute(OrderDTO dto)
    {
        FindOrder findOrder = new FindOrder(_orderRepository);
        OrderDTO orderDto = findOrder.Execute((long) dto.Id!);

        OrderBO bo = OrderMapper.ToBO(orderDto);
        OrderBO newBO = OrderMapper.ToBO(dto);

        bo.UpdateOrder(newBO);
        bo.CalculateAmount();

        bo = _orderRepository.Update(bo);

        return OrderMapper.ToDTO(bo);
    }

}

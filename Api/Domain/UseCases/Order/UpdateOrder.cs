using InventoryApi.Domain.Dto.Request;
using InventoryApi.Domain.Dto.Response;
using InventoryApi.Domain.Entities;
using InventoryApi.Domain.Mappers;
using InventoryApi.Domain.Repository;
using InventoryApi.Domain.UseCases.Supplier;

namespace InventoryApi.Domain.UseCases.Order;

// TODO: Reevaluate usecase
public class UpdateOrder
{
    private readonly IOrderRepository _orderRepository;
    private readonly ISupplierRepository _supplierRepository;

    public UpdateOrder(IOrderRepository orderRepository, ISupplierRepository supplierRepository)
    {
        _orderRepository = orderRepository;
        _supplierRepository = supplierRepository;
    }

    public OrderResponseDTO Execute(OrderRequestDTO dto)
    {
        Validate(dto);
        CalculateAmount(dto);

        OrderBO bo = OrderMapper.ToBO(dto);
        OrderBO created = _orderRepository.Update(bo);

        return OrderMapper.ToDTO(created);
    }

    private void Validate(OrderRequestDTO dto)
    {
        FindSupplier findSupplier = new FindSupplier(_supplierRepository);
        findSupplier.Execute(dto.SupplierId);

        dto.Status = OrderStatus.Pending;
    }

    private void CalculateAmount(OrderRequestDTO dto)
    {
        CalculateAmount calculateAmount = new CalculateAmount();
        List<OrderItemBO> orderItems = dto.Items.Select(OrderItemMapper.ToBO).ToList();

        decimal amount = calculateAmount.Execute(orderItems);

        dto.Total = amount;
    }
}

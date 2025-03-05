using InventoryApi.Domain.Dto.Request;
using InventoryApi.Domain.Dto.Response;
using InventoryApi.Domain.Entities;
using InventoryApi.Domain.Mappers;
using InventoryApi.Domain.Repository;
using InventoryApi.Domain.UseCases.OrderItem;
using InventoryApi.Domain.UseCases.Supplier;

namespace InventoryApi.Domain.UseCases.Order;

public class CreateOrder
{
    private readonly IOrderRepository _orderRepository;
    private readonly ISupplierRepository _supplierRepository;

    public CreateOrder(IOrderRepository orderRepository, ISupplierRepository supplierRepository)
    {
        _orderRepository = orderRepository;
        _supplierRepository = supplierRepository;
    }

    public OrderResponseDTO Execute(OrderRequestDTO dto)
    {
        Validate(dto);
        CalculateAmount(dto);

        OrderBO bo = OrderMapper.ToBO(dto);
        OrderBO created = _orderRepository.Create(bo);

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
        List<OrderItemBO> orderItems = dto.Items.Select(item => OrderItemMapper.ToBO(item)).ToList();

        decimal amount = calculateAmount.Execute(orderItems);

        dto.Total = amount;
    }
}

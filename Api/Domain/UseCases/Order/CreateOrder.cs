using InventoryApi.Domain.Dto;
using InventoryApi.Domain.Dto.Request;
using InventoryApi.Domain.Entities;
using InventoryApi.Domain.Mappers;
using InventoryApi.Domain.Repository;
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

    public OrderDTO Execute(OrderDTO dto)
    {
        Validate(dto);
        CalculateAmount(dto);

        OrderBO bo = OrderMapper.ToBO(dto);
        OrderBO created = _orderRepository.Create(bo);

        return OrderMapper.ToDTO(created);
    }

    private void Validate(OrderDTO dto)
    {
        FindSupplier findSupplier = new FindSupplier(_supplierRepository);
        SupplierDTO supplier = findSupplier.Execute((long) dto.Supplier.Id);

        dto.Status = OrderStatus.Pending;
    }

    private void CalculateAmount(OrderDTO dto)
    {
        CalculateAmount calculateAmount = new CalculateAmount();
        List<OrderItemBO> orderItems = dto.Items.Select(OrderItemMapper.ToBO).ToList();

        decimal amount = calculateAmount.Execute(orderItems);

        dto.Total = amount;
    }
}

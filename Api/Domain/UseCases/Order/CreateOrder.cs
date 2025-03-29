using Api.Domain.Dto;
using Api.Domain.Dto.Request;
using Api.Domain.Entities;
using Api.Domain.Mappers;
using Api.Domain.Repository;
using Api.Domain.UseCases.Supplier;

namespace Api.Domain.UseCases.Order;

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

        OrderBO bo = OrderMapper.ToBO(dto);
        bo.CalculateAmount();

        OrderBO created = _orderRepository.Create(bo);

        return OrderMapper.ToDTO(created);
    }

    private void Validate(OrderDTO dto)
    {
        FindSupplier findSupplier = new FindSupplier(_supplierRepository);
        SupplierDTO supplier = findSupplier.Execute((long) dto.Supplier.Id!);

        dto.Status = OrderStatus.Pending;
        dto.Supplier = supplier;
    }
}

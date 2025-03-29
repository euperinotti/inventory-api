using Api.Domain.Assertions;
using Api.Domain.Dto.Request;
using Api.Domain.Entities;
using Api.Domain.Mappers;
using Api.Domain.Repository;
using Api.Domain.UseCases.Order;
using Api.Domain.UseCases.Product;

namespace Api.Domain.UseCases.OrderItem;

public class AddToOrder
{
    private readonly IOrderItemRepository _repository;
    private readonly IOrderRepository _orderRepository;
    private readonly IProductRepository _productRepository;
    private readonly ISupplierRepository _supplierRepository;

    public AddToOrder(
        IOrderItemRepository repository,
        IOrderRepository orderRepository,
        IProductRepository productRepository,
        ISupplierRepository supplierRepository)
    {
        _repository = repository;
        _orderRepository = orderRepository;
        _productRepository = productRepository;
        _supplierRepository = supplierRepository;
    }

    public OrderItemDTO Execute(OrderItemDTO itemDTO, OrderBO orderBO)
    {
        ValidateProduct(itemDTO);
        ValidateOrder(itemDTO, orderBO);

        OrderItemBO bo = OrderItemMapper.ToBO(itemDTO);
        OrderItemBO created = _repository.Create(bo);

        RecalculateTotal(orderBO);

        return OrderItemMapper.ToDTO(created);
    }

    private void ValidateProduct(OrderItemDTO itemDTO)
    {
        FindProduct findProduct = new FindProduct(_productRepository);
        findProduct.Execute(itemDTO.ProductId);
    }

    private void ValidateOrder(OrderItemDTO itemDTO, OrderBO orderBO)
    {
        FindOrder findOrder = new FindOrder(_orderRepository);
        OrderDTO attachedOrder = findOrder.Execute(itemDTO.OrderId);

        Assert.IsEqual(itemDTO.OrderId, (long) orderBO.Id, "Invalid order id");
    }

    private void RecalculateTotal(OrderBO orderBO)
    {
        UpdateOrder updateOrder = new UpdateOrder(_orderRepository, _supplierRepository);
        updateOrder.Execute(OrderMapper.ToDTO(orderBO));
    }
}

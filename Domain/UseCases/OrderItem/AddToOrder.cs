using InventoryApi.Domain.Assertions;
using InventoryApi.Domain.Dto.Request;
using InventoryApi.Domain.Dto.Response;
using InventoryApi.Domain.Entities;
using InventoryApi.Domain.Mappers;
using InventoryApi.Domain.Repository;
using InventoryApi.Domain.UseCases.Order;
using InventoryApi.Domain.UseCases.Product;

namespace InventoryApi.Domain.UseCases.OrderItem;

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

    public OrderItemResponseDTO Execute(OrderItemRequestDTO itemDTO, OrderBO orderBO)
    {
        ValidateProduct(itemDTO);
        ValidateOrder(itemDTO, orderBO);

        OrderItemBO bo = OrderItemMapper.ToBO(itemDTO);
        OrderItemBO created = _repository.Create(bo);

        RecalculateTotal(orderBO);

        return OrderItemMapper.ToDTO(created);
    }

    private void ValidateProduct(OrderItemRequestDTO itemDTO)
    {
        FindProduct findProduct = new FindProduct(_productRepository);
        findProduct.Execute(itemDTO.ProductId);
    }

    private void ValidateOrder(OrderItemRequestDTO itemDTO, OrderBO orderBO)
    {
        FindOrder findOrder = new FindOrder(_orderRepository);
        OrderResponseDTO attachedOrder = findOrder.Execute(itemDTO.OrderId);

        Assert.IsEqual(itemDTO.OrderId, (long) orderBO.Id, "Invalid order id");
    }

    private void RecalculateTotal(OrderBO orderBO)
    {
        UpdateOrder updateOrder = new UpdateOrder(_orderRepository, _supplierRepository);
        updateOrder.Execute(OrderMapper.ToRequestDTO(orderBO));
    }
}

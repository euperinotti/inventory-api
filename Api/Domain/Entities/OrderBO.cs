using Api.Domain.Assertions;
using Api.Domain.Enums;

namespace Api.Domain.Entities;

public class OrderBO : AbstractEntityBO<long?>
{
    private OrderStatus _status;
    private SupplierBO _supplier;
    private List<OrderItemBO> _items;
    private decimal _total;

    public OrderBO(long? id, OrderStatus status, List<OrderItemBO> items, decimal total,
        SupplierBO supplier, DateTime createdAt,
        DateTime updatedAt) :
        base(id, createdAt, updatedAt)
    {
        Status = status;
        Items = items;
        Total = total;
        Supplier = supplier;

        Validate();
    }

    public OrderStatus Status { get => _status; private set => _status = value; }
    public SupplierBO Supplier { get => _supplier; private set => _supplier = value; }
    public List<OrderItemBO> Items { get => _items; private set => _items = value; }
    public decimal Total { get => _total; private set => _total = value; }

    private void Validate()
    {
        Assert.IsNotNull(Supplier, "Order must have a supplier");
        Assert.IsGreaterThanOrEqual(Total, 0, "Total must be greater than zero");
        Assert.IsLessThan(CreatedAt, DateTime.Now, "Order cannot be created in the future");
    }

    public void UpdateOrder(OrderStatus status, List<OrderItemBO> items)
    {
        Status = status;
        Items = items;

        UpdatedAtNow();
        CalculateAmount();
    }

    public void AddItem(OrderItemBO orderItem)
    {
        OrderItemBO? item = Items.Find(e => orderItem.Product.Id == e.Product.Id);

        if (item is not null)
        {
            item.AddQuantity(orderItem.Quantity);
        }
        else
        {
            Items.Add(orderItem);
        }

        CalculateAmount();
    }

    public void RemoveItem(OrderItemBO orderItem)
    {
        OrderItemBO? item = Items.Find(e => orderItem.Product.Id == e.Product.Id);

        if (item is null)
        {
            return;
        }

        Items.Remove(item);

        CalculateAmount();
    }

    public void CalculateAmount()
    {
        Total = decimal.Zero;
        Items.ForEach(e => Total += e.Quantity * e.UnitPrice);
    }

    public void Cancel()
    {
        if (Status is OrderStatus.Shipped or OrderStatus.Done)
        {
            throw new Exception("Cannot Cancel an already shipped or done order");
        }

        Status = OrderStatus.Canceled;
        UpdatedAtNow();
    }

}

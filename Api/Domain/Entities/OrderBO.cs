using InventoryApi.Domain.Assertions;

namespace InventoryApi.Domain.Entities;

public class OrderBO : AbstractEntityBO
{
    // TODO: Separate properties from attributes
    public DateTime Date { get; private set; }
    public OrderStatus Status { get; private set; }
    public SupplierBO Supplier { get; private set; }
    public List<OrderItemBO> Items { get; private set; }
    public decimal Total { get; private set; }

    public OrderBO(long? id, DateTime date, OrderStatus status, List<OrderItemBO> items, decimal total,
        SupplierBO supplier, DateTime createdAt,
        DateTime updatedAt) :
        base(id, createdAt, updatedAt)
    {
        Date = date;
        Status = status;
        Items = items;
        Total = total;
        Supplier = supplier;

        Validate();
    }

    private void Validate()
    {
        Assert.IsNotNull(Supplier, "Order must have a supplier");
        Assert.IsGreaterThanOrEqual(Total, 0, "Total must be greater than zero");
    }

    public void UpdateOrder(OrderBO bo)
    {
        Status = bo.Status;
        Items = bo.Items;

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

    // TODO: Leave the calculation for the business object or the usecase?
    public void CalculateAmount()
    {
        foreach (OrderItemBO item in Items)
        {
            Total += item.Quantity * item.UnitPrice;
        }
    }

}

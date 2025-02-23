using InventoryApi.Domain.Assertions;

namespace InventoryApi.Domain.Entities;

public class OrderBO : AbstractEntityBO
{
    public DateTime Date { get; private set; }
    public OrderStatus Status { get; private set; }
    public SupplierBO Supplier { get; private set; }
    public decimal Total { get; private set; }

    public OrderBO(long? id, DateTime date, OrderStatus status, decimal total, SupplierBO supplier, DateTime createdAt,
        DateTime updatedAt) :
        base(id, createdAt, updatedAt)
    {
        Date = date;
        Status = status;
        Total = total;
        Supplier = supplier;

        Validate();
    }

    private void Validate()
    {
        Assert.IsNull(Supplier, "Order must have a supplier");
        Assert.IsGreaterThanOrEqual(Total, 0, "Total must be greater than zero");
    }
}
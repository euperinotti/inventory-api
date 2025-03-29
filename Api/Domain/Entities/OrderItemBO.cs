using Api.Domain.Assertions;

namespace Api.Domain.Entities;

public class OrderItemBO : AbstractEntityBO<long?>
{
    public long? Id { get; private set; }
    public ProductBO Product { get; private set; }
    public OrderBO Order { get; private set; }
    public int Quantity { get; private set; }
    public decimal UnitPrice { get; private set; }

    public OrderItemBO(long? id, ProductBO product, OrderBO order, int quantity, decimal unitPrice) :
        base(id, DateTime.Now, DateTime.Now)
    {
        Id = id;
        Product = product;
        Order = order;
        Quantity = quantity;
        UnitPrice = unitPrice;

        Validate();
    }

    private void Validate()
    {
        Assert.IsNotNull(Product, "Order item must have a product");
        Assert.IsNotNull(Order, "Order item must have a parent order");
        Assert.IsGreaterThan(Quantity, 0, "Quantity must be greater than zero");
        Assert.IsGreaterThan(UnitPrice, 0, "Unit price must be greater than zero");
    }

    public void UpdateItem(OrderItemBO item)
    {
        Quantity = item.Quantity;
    }

    public void AddQuantity(int quantity)
    {
        Quantity += quantity;
    }
}

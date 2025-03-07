using InventoryApi.Domain.Assertions;

namespace InventoryApi.Domain.Entities;

public class TransactionBO : AbstractEntityBO
{
    private DateTime _date;
    private TransactionType _type;
    private decimal _value;
    private ProductBO _product;
    private OrderBO _order;

    public TransactionBO(long? id, DateTime date, TransactionType type, decimal value, ProductBO product, OrderBO order) :
        base(id, DateTime.Now,  DateTime.Now)
    {
        Date = date;
        Type = type;
        Value = value;
        Product = product;
        Order = order;

        Validate();
    }

    public DateTime Date
    {
        get => _date;
        private set => _date = value;
    }

    public TransactionType Type
    {
        get => _type;
        private set => _type = value;
    }

    public decimal Value
    {
        get => _value;
        private set => _value = value;
    }

    public ProductBO Product
    {
        get => _product;
        private set => _product = value;
    }

    public OrderBO Order
    {
        get => _order;
        private set => _order = value;
    }

    private void Validate()
    {
        Assert.IsGreaterThan(Value, 0, "Transaction value must be greater than zero");
        Assert.IsNotNull(Product, "Transaction must have a product");
        Assert.IsNotNull(Order, "Transaction must have an order");
    }


}

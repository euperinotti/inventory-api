namespace inventory_api.Domain.Entities;

public class TransactionBO
{
    public long? Id { get; private set; }
    public DateTime Date { get; private set; }
    public TransactionType Type { get; private set; }
    public decimal Value { get; private set; }
    public ProductBO Product { get; private set; }
    public OrderBO Order { get; private set; }

    public TransactionBO(long? id, DateTime date, TransactionType type, decimal value, ProductBO product, OrderBO order)
    {
        Id = id;
        Date = date;
        Type = type;
        Value = value;
        Product = product;
        Order = order;

        Validate();
    }

    public void Validate()
    {
        // TODO: Validations
    }


}
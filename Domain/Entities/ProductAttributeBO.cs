namespace InventoryApi.Domain.Entities;

public class ProductAttributeBO
{
    public long? Id { get; private set; }
    public string Key { get; private set; }
    public string Value { get; private set; }

    public ProductAttributeBO(long? id, string key, string value)
    {
        Id = id;
        Key = key;
        Value = value;
    }

    public void Validate()
    {
        // TODO: Validations
    }
}
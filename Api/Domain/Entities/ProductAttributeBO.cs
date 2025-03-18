using InventoryApi.Domain.Assertions;

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

        Validate();
    }

    private void Validate()
    {
        Assert.IsNotNull(Key, "Product attribute must have a key");
        Assert.IsNotNull(Value, "Product attribute must have a value");
    }
}

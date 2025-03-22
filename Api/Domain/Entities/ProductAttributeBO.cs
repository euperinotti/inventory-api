using InventoryApi.Domain.Assertions;

namespace InventoryApi.Domain.Entities;

public class ProductAttributeBO : AbstractEntityBO<long?>
{
    public string Key { get; private set; }
    public string Value { get; private set; }
    public string DataType { get; private set; }

    public ProductAttributeBO(long? id, string key, string value, AttributeDataType dataType) :
        base(id, DateTime.Now, DateTime.Now)
    {
        Key = key;
        Value = value;
        DataType = dataType.ToString();

        Validate();
    }

    private void Validate()
    {
        Assert.IsNotNull(Key, "Product attribute must have a key");
        Assert.IsNotNull(Value, "Product attribute must have a value");
    }
}

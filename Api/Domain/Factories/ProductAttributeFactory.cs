using InventoryApi.Domain.Entities;

namespace InventoryApi.Domain.Factories;

public class ProductAttributeFactory
{
    // TODO: Make this generic and solve
    public static ProductAttributeBO<object> Create<T>(long? id, string key, T value, AttributeDataType dataType)
    {
        return dataType switch
        {
            AttributeDataType.String => new ProductAttributeBO<string>(id, key, (string)value, dataType),
            AttributeDataType.Integer => new ProductAttributeBO<int>(id, key, Convert.ToInt32(value), dataType),
            AttributeDataType.Decimal => new ProductAttributeBO<decimal>(id, key, Convert.ToDecimal(value), dataType),
            AttributeDataType.Boolean => new ProductAttributeBO<bool>(id, key, Convert.ToBoolean(value), dataType),
            _ => throw new ArgumentException("Unsupported data type")
        };
    }
}

using InventoryApi.Domain.Entities;

namespace InventoryApi.Domain.Repository;

public interface IOrderItemRepository : ICrudRepository<OrderItemBO, long>
{
    List<OrderItemBO> FindByOrderId(long orderId);
}

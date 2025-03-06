using InventoryApi.Domain.Entities;

namespace InventoryApi.Domain.Repository;

public interface IOrderRepository : ICrudRepository<OrderBO, long>
{
}
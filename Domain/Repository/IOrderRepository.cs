using inventory_api.Domain.Entities;

namespace inventory_api.Domain.Repository;

public interface IOrderRepository : ICrudRepository<OrderBO, long>
{
}
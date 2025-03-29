using Api.Domain.Entities;

namespace Api.Domain.Repository;

public interface IOrderItemRepository : ICrudRepository<OrderItemBO, long>
{
    List<OrderItemBO> FindByOrderId(long orderId);
}

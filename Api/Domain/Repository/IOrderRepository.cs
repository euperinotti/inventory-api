using Api.Domain.Entities;

namespace Api.Domain.Repository;

public interface IOrderRepository : ICrudRepository<OrderBO, long>
{
}
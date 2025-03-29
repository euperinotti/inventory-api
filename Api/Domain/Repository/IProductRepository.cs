using Api.Domain.Entities;

namespace Api.Domain.Repository;

public interface IProductRepository : ICrudRepository<ProductBO, long>
{

}
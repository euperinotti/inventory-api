using InventoryApi.Domain.Entities;

namespace InventoryApi.Domain.Repository;

public interface IProductRepository : ICrudRepository<ProductBO, long>
{
    
}
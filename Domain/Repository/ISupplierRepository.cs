using InventoryApi.Domain.Entities;

namespace InventoryApi.Domain.Repository;

public interface ISupplierRepository : ICrudRepository<SupplierBO, long>
{
}
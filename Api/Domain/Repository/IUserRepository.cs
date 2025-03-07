using InventoryApi.Domain.Entities;

namespace InventoryApi.Domain.Repository;

public interface IUserRepository : ICrudRepository<UserBO, long>
{
    UserBO? FindByEmail(string email);
}

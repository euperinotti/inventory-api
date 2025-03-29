using Api.Domain.Entities;

namespace Api.Domain.Repository;

public interface IUserRepository : ICrudRepository<UserBO, long>
{
    UserBO? FindByEmail(string email);
}

using Api.Domain.Entities;

namespace Api.Domain.Repository;

public interface IUserSessionRepository : ICrudRepository<UserSessionBO, long>
{
    UserSessionBO? FindLastSession(UserBO user);
}

using Api.Domain.Entities;

namespace Api.Domain.Security;

public interface IJWTAuth
{
  public string GenerateToken(UserBO user);
}

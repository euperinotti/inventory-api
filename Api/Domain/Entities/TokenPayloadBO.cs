namespace Api.Domain.Entities;

public class TokenPayloadBO {
  public string Email { get; private set; }
  public string Password { get; private set; }
  public DateTime CreatedAt { get; private set; }
  public DateTime LastLoginAt { get; private set; }
  public int Attempts { get; private set; }
  public int ExpiresIn { get; private set; }

  public DateTime ExpiresAt { get; private set; }

  private TokenPayloadBO(string email, string password, DateTime createdAt, DateTime lastLoginAt, int attempts, int expiresIn) {
    Email = email;
    Password = password;
    CreatedAt = createdAt;
    LastLoginAt = lastLoginAt;
    Attempts = attempts;
    ExpiresIn = expiresIn;
    ExpiresAt = createdAt.AddSeconds(expiresIn);
  }

  public static TokenPayloadBO Of(UserBO user) {
    return new TokenPayloadBO(user.Email, user.Password, DateTime.Now, DateTime.Now, 1, 7200);
  }
}

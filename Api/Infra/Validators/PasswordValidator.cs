using Api.Domain.Assertions;
using Api.Domain.Validators;
using Microsoft.AspNetCore.Identity;

namespace Api.Infra.Validators;

public class PasswordValidator : IPasswordValidator
{
  public void Validate(string password)
  {
    Assert.IsGreaterThanOrEqual(password.Length, 8, "Password must be at least 8 characters long");

    if (!password.Any(char.IsUpper)) {
      throw new ArgumentException("Password must contain at least one uppercase letter");
    }

    if (!password.Any(char.IsLower)) {
      throw new ArgumentException("Password must contain at least one lowercase letter");
    }

    if (!password.Any(char.IsDigit)) {
      throw new ArgumentException("Password must contain at least one digit");
    }

    if (!password.Any(ch => !char.IsLetterOrDigit(ch) && !char.IsWhiteSpace(ch))) {
      throw new ArgumentException("Password must contain at least one special character");
    }
  }
}
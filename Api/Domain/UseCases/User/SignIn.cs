using Api.Domain.Dto;
using Api.Domain.Repository;
using Api.Domain.Security;
using Api.Domain.Validators;

namespace Api.Domain.UseCases.User;

// TODO: Implement and search for details of implementation
/**
 * 1. Validate user credentials
 * 2. Generate token
 * 3. Send account confirmation email
 * 4. Start session
 * 5. Return token
 */
public class SignIn
{
    private readonly IUserRepository _repository;
    private readonly IEncrypter _encrypter;
    private readonly IEmailValidator _emailValidator;

    public SignIn(IUserRepository repository, IEncrypter encrypter, IEmailValidator emailValidator)
    {
        _repository = repository;
        _encrypter = encrypter;
        _emailValidator = emailValidator;
    }

    public UserDTO Execute(UserDTO dto)
    {
        return null;
    }

    private void Validate(UserDTO dto)
    {

    }
}

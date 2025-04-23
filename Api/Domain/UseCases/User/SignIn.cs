using Api.Domain.Assertions;
using Api.Domain.Dto;
using Api.Domain.Entities;
using Api.Domain.Repository;
using Api.Domain.Security;
using Api.Domain.Validators;

namespace Api.Domain.UseCases.User;

// TODO: Implement and search for details of implementation
/**
 * 1. Validate user credentials - OK
 * 2. Generate token - OK
 * 3. Send account confirmation email
 * 4. Start session
 * 5. Return token
 */
public class SignIn
{
    private readonly IUserRepository _repository;
    private readonly IUserSessionRepository _userSessionRepository;
    private readonly IEncrypter _encrypter;
    private readonly IEmailValidator _emailValidator;
    private readonly IJWTAuth _jwtAuth;

    public SignIn(IUserRepository repository, IEncrypter encrypter, IEmailValidator emailValidator, IJWTAuth jwtAuth)
    {
        _repository = repository;
        _encrypter = encrypter;
        _emailValidator = emailValidator;
        _jwtAuth = jwtAuth;
    }

    public UserDTO Execute(UserDTO dto)
    {
        Validate(dto);

        UserBO? user = _repository.FindByCredentials(dto.Email, dto.Password);
        Assert.IsNotNull(user, "Invalid credentials");

        string token = _jwtAuth.GenerateToken(user!);

        InitiateSession(user!, token);

        return null;
    }

    private void Validate(UserDTO dto)
    {
        string password = _encrypter.Hash(dto.Password);
        dto.Password = password;
        _emailValidator.Validate(dto.Email);
    }

    private void InitiateSession(UserBO user, string token)
    {
        UserSessionBO session = UserSessionBO.NewSession(user);
        session.AttemptLogin();

        UserSessionBO lastSession = _userSessionRepository.FindLastSession(user.Id!);
    }
}

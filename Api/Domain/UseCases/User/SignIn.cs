using Api.Domain.Assertions;
using Api.Domain.Dto;
using Api.Domain.Entities;
using Api.Domain.Mappers;
using Api.Domain.Repository;
using Api.Domain.Security;
using Api.Domain.Validators;

namespace Api.Domain.UseCases.User;

public class SignIn
{
    private readonly IUserRepository _repository;
    private readonly IUserSessionRepository _sessionRepository;
    private readonly IEncrypter _encrypter;
    private readonly IEmailValidator _emailValidator;
    private readonly IJWTAuth _jwtAuth;

    public SignIn(IUserRepository repository, IUserSessionRepository sessionRepository, IEncrypter encrypter, IEmailValidator emailValidator, IJWTAuth jwtAuth)
    {
        _repository = repository;
        _sessionRepository = sessionRepository;
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

        UserDTO response = UserMapper.ToDTO(user!);
        response.Token = token;

        return response;
    }

    private void Validate(UserDTO dto)
    {
        string password = _encrypter.Hash(dto.Password);
        dto.Password = password;

        _emailValidator.Validate(dto.Email);
    }
}

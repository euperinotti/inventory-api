using Api.Domain.Assertions;
using Api.Domain.Dto;
using Api.Domain.Entities;
using Api.Domain.Mappers;
using Api.Domain.Repository;
using Api.Domain.Security;
using Api.Domain.Validators;

namespace Api.Domain.UseCases.User;

public class SignUp
{
    private readonly IUserRepository _repository;
    private readonly IEncrypter _encrypter;
    private readonly IPasswordValidator _passwordValidator;

    public SignUp(IUserRepository repository, IEncrypter encrypter, IPasswordValidator passwordValidator)
    {
        _repository = repository;
        _encrypter = encrypter;
        _passwordValidator = passwordValidator;
    }

    public UserDTO Execute(UserDTO dto)
    {
        Validate(dto);
        EncryptPassword(dto);

        UserBO bo = UserMapper.ToBO(dto);
        UserBO created = _repository.Create(bo);

        return UserMapper.ToDTO(created);
    }

    private void Validate(UserDTO dto)
    {
        UserBO? user = _repository.FindByEmail(dto.Email);
        Assert.IsNotNull(user, "This email is already registered");

        _passwordValidator.Validate(dto.Password);
    }

    private void EncryptPassword(UserDTO dto)
    {
        string hashed = _encrypter.Hash(dto.Password);
        dto.Password = hashed;
    }
}

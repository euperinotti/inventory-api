using Api.Domain.Assertions;
using Api.Domain.Dto;
using Api.Domain.Entities;
using Api.Domain.Repository;
using Api.Domain.Security;
using Api.Domain.Validators;

namespace Api.Domain.UseCases.User;

// TODO: Implement
public class ResetPassword
{
    private readonly IUserRepository _repository;
    private readonly IEncrypter _encrypter;
    private readonly IPasswordValidator _validator;

    public ResetPassword(IUserRepository repository, IEncrypter encrypter)
    {
        _repository = repository;
        _encrypter = encrypter;
    }

    public void Execute(UserDTO dto)
    {
        UserBO? user = _repository.FindByCredentials(dto.Email, dto.Password);

        Assert.IsNotNull(user, "User not found");

        _validator.Validate(dto.Password);

        dto.Password = _encrypter.Hash(dto.Password);
        user.ResetPassword(dto.Password);

        _repository.Update(user!);
    }
}

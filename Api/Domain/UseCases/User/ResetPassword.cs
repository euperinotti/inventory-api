using Api.Domain.Assertions;
using Api.Domain.Dto;
using Api.Domain.Entities;
using Api.Domain.Repository;
using Api.Domain.Security;
using Api.Domain.Validators;

namespace Api.Domain.UseCases.User;

public class ResetPassword
{
    private readonly IUserRepository _repository;
    private readonly IEncrypter _encrypter;
    private readonly IPasswordValidator _validator;

    public ResetPassword(IUserRepository repository, IEncrypter encrypter, IPasswordValidator validator)
    {
        _repository = repository;
        _encrypter = encrypter;
        _validator = validator;
    }

    public void Execute(ResetPasswordDTO dto)
    {
        UserBO? user = _repository.FindByCredentials(dto.Email, dto.OldPassword);

        Assert.IsNotNull(user, "User not found");

        _validator.Validate(dto.NewPassword);

        dto.NewPassword = _encrypter.Hash(dto.NewPassword);
        user!.ResetPassword(dto.NewPassword);

        _repository.Update(user);
    }
}

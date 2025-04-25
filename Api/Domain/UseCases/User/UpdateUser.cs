using Api.Domain.Assertions;
using Api.Domain.Dto;
using Api.Domain.Entities;
using Api.Domain.Mappers;
using Api.Domain.Repository;
using Api.Domain.Validators;

namespace Api.Domain.UseCases.User;

public class UpdateUser
{
    private readonly IUserRepository _repository;
    // TODO: Move this validations to a UserValidator class?
    private readonly IEmailValidator _emailValidator;
    private readonly IPasswordValidator _passwordValidator;

    public UpdateUser(IUserRepository repository, IEmailValidator emailValidator, IPasswordValidator passwordValidator)
    {
        _repository = repository;
        _emailValidator = emailValidator;
        _passwordValidator = passwordValidator;
    }

    public UserDTO Execute(UserDTO dto)
    {
        UserBO? user = _repository.FindByCredentials(dto.Email, dto.Password);
        Assert.IsNotNull(user, "User not found");

        UserBO bo = UserMapper.ToBO(dto);

        user!.Update(bo);

        _repository.Update(user);

        return UserMapper.ToDTO(user);
    }
}

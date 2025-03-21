using InventoryApi.Domain.Dto;
using InventoryApi.Domain.Repository;
using InventoryApi.Domain.Security;
using InventoryApi.Domain.Validators;

namespace InventoryApi.Domain.UseCases.User;

// TODO: Implement and search for details of implementation
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
    }

    private void Validate(UserDTO dto)
    {

    }
}

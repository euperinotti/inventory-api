using InventoryApi.Application.Dto.Request;
using InventoryApi.Application.Dto.Response;
using InventoryApi.Domain.Assertions;
using InventoryApi.Domain.Entities;
using InventoryApi.Domain.Mappers;
using InventoryApi.Domain.Repository;
using InventoryApi.Domain.Security;

namespace InventoryApi.Domain.UseCases.User;

public class SignUp
{
    private readonly IUserRepository _repository;
    private readonly IEncrypter _encrypter;

    public SignUp(IUserRepository repository, IEncrypter encrypter)
    {
        _repository = repository;
        _encrypter = encrypter;
    }

    public UserResponseDTO Execute(UserRequestDTO dto)
    {
        Validate(dto);
        EncryptPassword(dto);

        UserBO bo = UserMapper.ToBO(dto);
        UserBO created = _repository.Create(bo);

        return UserMapper.ToDTO(created);
    }

    private void Validate(UserRequestDTO dto)
    {
        UserBO? user = _repository.FindByEmail(dto.Email);
        Assert.IsNotNull(user, "This email is already registered");
    }

    private void EncryptPassword(UserRequestDTO dto)
    {
        string hashed = _encrypter.Hash(dto.Password);
        dto.Password = hashed;
    }
}

using InventoryApi.Application.Dto.Request;
using InventoryApi.Application.Dto.Response;
using InventoryApi.Domain.Assertions;
using InventoryApi.Domain.Dto;
using InventoryApi.Domain.Entities;
using InventoryApi.Domain.Mappers;
using InventoryApi.Domain.Repository;

namespace InventoryApi.Domain.UseCases.User;

public class FindUser
{
    private readonly IUserRepository _repository;

    public FindUser(IUserRepository repository)
    {
        _repository = repository;
    }

    public List<UserDTO> Execute()
    {
        IEnumerable<UserBO> users = _repository.FindAll();

        return users.Select(UserMapper.ToDTO).ToList();
    }

    public UserDTO ExecuteById(UserRequestDTO dto)
    {
        UserBO? bo = _repository.FindById((long) dto.Id);
        Assert.IsNotNull(bo, "User not found");

        return UserMapper.ToDTO(bo);
    }

    public UserDTO ExecuteByEmail(UserRequestDTO dto)
    {
        UserBO? bo = _repository.FindByEmail(dto.Email);
        Assert.IsNotNull(bo, "User not found");

        return UserMapper.ToDTO(bo);
    }

}

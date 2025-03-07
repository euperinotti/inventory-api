using InventoryApi.Application.Dto.Request;
using InventoryApi.Application.Dto.Response;
using InventoryApi.Domain.Entities;

namespace InventoryApi.Domain.Mappers;

public static class UserMapper
{
    public static UserResponseDTO ToDTO(UserBO bo)
    {
        UserResponseDTO dto = new UserResponseDTO();
        dto.Id = bo.Id;
        dto.Name = bo.Name;
        dto.Email = bo.Email;
        dto.Password = bo.Password;

        return dto;
    }

    public static UserBO ToBO(UserRequestDTO dto)
    {
        // TODO: Arrumar questao do created e updated date time
        return new UserBO(dto.Id, dto.Name, dto.Email, dto.Password, DateTime.Now, DateTime.Now);
    }
}

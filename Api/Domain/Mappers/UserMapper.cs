﻿using InventoryApi.Application.Dto.Request;
using InventoryApi.Application.Dto.Response;
using InventoryApi.Domain.Dto;
using InventoryApi.Domain.Entities;

namespace InventoryApi.Domain.Mappers;

public static class UserMapper
{
    public static UserDTO ToDTO(UserBO bo)
    {
        UserDTO dto = new UserDTO();
        dto.Id = bo.Id;
        dto.Name = bo.Name;
        dto.Email = bo.Email;
        dto.Password = bo.Password;

        return dto;
    }

    public static UserBO ToBO(UserDTO dto)
    {
        return new UserBO(dto.Id, dto.Name, dto.Email, dto.Password, DateTime.Now, DateTime.Now);
    }
}

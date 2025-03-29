using Api.Domain.Dto;
using Api.Domain.Entities;
using Api.Domain.Dto.Request;

namespace Api.Domain.Mappers;

public static class SupplierMapper
{
    public static SupplierDTO ToDTO(SupplierBO bo)
    {
        SupplierDTO dto = new SupplierDTO();
        dto.Id = bo.Id;
        dto.CreatedAt = bo.CreatedAt;
        dto.UpdatedAt = bo.UpdatedAt;
        dto.Name = bo.Name;
        dto.Cnpj = bo.Cnpj;
        dto.Address = bo.Address;
        dto.Contact = bo.Contact;

        return dto;
    }

    public static SupplierBO ToBO(SupplierRequestDTO dto)
    {
        return new SupplierBO(dto.Id, dto.Name, dto.Cnpj, dto.Address, dto.Contact, dto.CreatedAt, dto.UpdatedAt);
    }

    public static SupplierBO ToBO(SupplierDTO dto)
    {
        return new SupplierBO(dto.Id, dto.Name, dto.Cnpj, dto.Address, dto.Contact, dto.CreatedAt, dto.UpdatedAt);
    }
}

using InventoryApi.Domain.Entities;
using InventoryApi.Domain.Dto.Request;

namespace InventoryApi.Domain.Mappers;

public class SupplierMapper
{
    public static SupplierRequestDTO ToDTO(SupplierBO bo)
    {
        SupplierRequestDTO dto = new SupplierRequestDTO();
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
}
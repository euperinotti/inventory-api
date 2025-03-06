using InventoryApi.Domain.Entities;
using InventoryApi.Domain.Dto.Request;
using InventoryApi.Presentation.Dtos.Supplier;

namespace InventoryApi.Domain.Mappers;

public class SupplierMapper
{
    public static SupplierResponseDTO ToDTO(SupplierBO bo)
    {
        SupplierResponseDTO dto = new SupplierResponseDTO();
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
using InventoryApi.Domain.Dto.Request;
using InventoryApi.Domain.Dto.Response;
using InventoryApi.Domain.Entities;

namespace InventoryApi.Domain.Mappers;

public static class ProductMapper
{
    public static ProductBO ToBO(ProductRequestDTO dto) {
        return new ProductBO(dto.Id, dto.Name, dto.Description, dto.Price, dto.Quantity, dto.ImageURL, null);
    }

    public static ProductResponseDTO ToDTO(ProductBO bo) {
        ProductResponseDTO dto = new ProductResponseDTO();

        dto.Id = bo.Id;
        dto.Name = bo.Name;
        dto.Description = bo.Description;
        dto.Price = bo.Price;
        dto.Quantity = bo.Quantity;
        dto.ImageURL = bo.ImageURL;
        dto.Supplier = SupplierMapper.ToDTO(bo.Supplier);

        return dto;
    }
}
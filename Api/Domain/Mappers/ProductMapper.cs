﻿using Api.Domain.Dto.Request;
using Api.Domain.Dto.Response;
using Api.Domain.Entities;

namespace Api.Domain.Mappers;

public static class ProductMapper
{
    public static ProductBO ToBO(ProductDTO dto) {
        return new ProductBO(dto.Id, dto.Name, dto.Description, dto.Price, dto.Quantity, dto.ImageURL, SupplierMapper.ToBO(dto.Supplier));
    }

    public static ProductDTO ToDTO(ProductBO bo) {
        ProductDTO dto = new ProductDTO();

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

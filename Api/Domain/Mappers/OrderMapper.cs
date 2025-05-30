﻿using Api.Domain.Dto.Request;
using Api.Domain.Dto.Response;
using Api.Domain.Entities;

namespace Api.Domain.Mappers;

public static class OrderMapper
{
    public static OrderDTO ToDTO(OrderBO bo)
    {
        OrderDTO dto = new OrderDTO();
        dto.Id = bo.Id;
        dto.Status = bo.Status;
        dto.Total = bo.Total;
        dto.Supplier = SupplierMapper.ToDTO(bo.Supplier);
        dto.CreatedAt = bo.CreatedAt;
        dto.UpdatedAt = bo.UpdatedAt;

        return dto;
    }

    public static OrderBO ToBO(OrderDTO dto)
    {
        List<OrderItemBO> items = dto.Items.Select(OrderItemMapper.ToBO).ToList();
        SupplierBO supplier = SupplierMapper.ToBO(dto.Supplier);

        return new OrderBO(dto.Id,
            dto.Status,
            items,
            dto.Total,
            supplier,
            dto.CreatedAt,
            dto.UpdatedAt);
    }
}

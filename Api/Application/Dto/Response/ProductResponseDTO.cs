﻿using Api.Presentation.Dtos.Supplier;

namespace Api.Domain.Dto.Response;

public record ProductResponseDTO
{
    public long? Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public string ImageURL { get; set; }
    // public HashSet<ProductAttributeBO> Attributes { get; set; }
    public SupplierResponseDTO Supplier { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
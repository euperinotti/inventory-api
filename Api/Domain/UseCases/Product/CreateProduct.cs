﻿using InventoryApi.Domain.Assertions;
using InventoryApi.Domain.Dto.Request;
using InventoryApi.Domain.Entities;
using InventoryApi.Domain.Mappers;
using InventoryApi.Domain.Repository;

namespace InventoryApi.Domain.UseCases.Product;

public class CreateProduct
{
    private readonly IProductRepository _repository;
    private readonly ISupplierRepository _supplierRepository;

    public CreateProduct(IProductRepository repository, ISupplierRepository supplierRepository)
    {
        _repository = repository;
        _supplierRepository = supplierRepository;
    }

    public ProductDTO Execute(ProductDTO product)
    {
        Validate(product);

        ProductBO bo = ProductMapper.ToBO(product);

        ProductBO created = _repository.Create(bo);

        return ProductMapper.ToDTO(created);
    }

    private void Validate(ProductDTO product)
    {
        SupplierBO? supplierBo = _supplierRepository.FindById(product.SupplierId);
        Assert.IsNull(supplierBo, "Supplier not found");
    }
}

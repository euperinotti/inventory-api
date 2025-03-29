using Api.Domain.Assertions;
using Api.Domain.Dto.Request;
using Api.Domain.Entities;
using Api.Domain.Mappers;
using Api.Domain.Repository;

namespace Api.Domain.UseCases.Product;

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

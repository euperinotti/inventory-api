using Api.Domain.Assertions;
using Api.Domain.Dto.Request;
using Api.Domain.Entities;
using Api.Domain.Mappers;
using Api.Domain.Repository;

namespace Api.Domain.UseCases.Product;

public class UpdateProduct
{
    private readonly IProductRepository _repository;
    private readonly ISupplierRepository _supplierRepository;

    public UpdateProduct(IProductRepository repository, ISupplierRepository supplierRepository)
    {
        _repository = repository;
        _supplierRepository = supplierRepository;
    }

    public ProductDTO Execute(ProductDTO dto)
    {
        Validate(dto);
        ProductBO bo = FindProduct(dto);

        bo.UpdateProduct(ProductMapper.ToBO(dto));

        bo = _repository.Create(bo);

        return ProductMapper.ToDTO(bo);
    }

    private void Validate(ProductDTO dto)
    {
        FindProduct findProduct = new FindProduct(_repository);
        ProductDTO product = findProduct.Execute((long) dto.Id!);

        dto = product;

        SupplierBO? supplierBo = _supplierRepository.FindById(dto.SupplierId);
        Assert.IsNotNull(supplierBo!, "Supplier not found");
    }

    private ProductBO FindProduct(ProductDTO dto)
    {
        FindProduct findProduct = new FindProduct(_repository);
        return ProductMapper.ToBO(findProduct.Execute((long) dto.Id!));
    }
}

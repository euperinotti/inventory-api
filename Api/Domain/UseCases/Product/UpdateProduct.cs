using InventoryApi.Domain.Dto.Request;
using InventoryApi.Domain.Dto.Response;
using InventoryApi.Domain.Entities;
using InventoryApi.Domain.Mappers;
using InventoryApi.Domain.Repository;

namespace InventoryApi.Domain.UseCases.Product;

public class UpdateProduct
{
    private readonly IProductRepository _repository;
    private readonly ISupplierRepository _supplierRepository;

    public UpdateProduct(IProductRepository repository, ISupplierRepository supplierRepository)
    {
        _repository = repository;
        _supplierRepository = supplierRepository;
    }

    // TODO: Implement mapping from response dto to bo
    public ProductResponseDTO Execute(ProductRequestDTO product)
    {
        FindProduct usecase = new FindProduct(_repository);
        ProductResponseDTO dto = usecase.Execute((long) product.Id);

        ProductBO bo = ProductMapper.ToBO(product);

        ProductBO created = _repository.Create(bo);

        return ProductMapper.ToDTO(created);
    }

    public void Validate(ProductRequestDTO product)
    {
        SupplierBO supplierBo = _supplierRepository.FindById(product.SupplierId);
    }
}

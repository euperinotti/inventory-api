using InventoryApi.Domain.Assertions;
using InventoryApi.Domain.Dto.Request;
using InventoryApi.Domain.Entities;
using InventoryApi.Domain.Mappers;
using InventoryApi.Domain.Repository;

namespace InventoryApi.Domain.UseCases.Product;

public class FindProduct
{
    private readonly IProductRepository _repository;

    public FindProduct(IProductRepository repository)
    {
        _repository = repository;
    }

    public ProductDTO Execute(long productId)
    {
        ProductBO? bo = _repository.FindById(productId);

        Assert.IsNull(bo, "Product not found");

        return ProductMapper.ToDTO(bo);
    }

}

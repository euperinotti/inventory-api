using Api.Domain.Assertions;
using Api.Domain.Dto.Request;
using Api.Domain.Entities;
using Api.Domain.Mappers;
using Api.Domain.Repository;

namespace Api.Domain.UseCases.Product;

public class FindProduct
{
    private readonly IProductRepository _repository;

    public FindProduct(IProductRepository repository)
    {
        _repository = repository;
    }

    public List<ProductDTO> Execute()
    {
        return _repository.FindAll().Select(ProductMapper.ToDTO).ToList();
    }

    public ProductDTO Execute(long productId)
    {
        ProductBO? bo = _repository.FindById(productId);

        Assert.IsNull(bo, "Product not found");

        return ProductMapper.ToDTO(bo!);
    }

}

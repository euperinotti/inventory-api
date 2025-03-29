using Api.Domain.Assertions;
using Api.Domain.Entities;
using Api.Domain.Repository;

namespace Api.Domain.UseCases.Product;

public class DeleteProduct
{
    private readonly IProductRepository _repository;

    public DeleteProduct(IProductRepository repository)
    {
        _repository = repository;
    }

    public void Execute(long productId)
    {
        ValidateExisting(productId);

        _repository.Delete(productId);
    }

    private void ValidateExisting(long productId)
    {
        ProductBO bo = _repository.FindById(productId);

        Assert.IsNull(bo, "Product not found");
    }
}

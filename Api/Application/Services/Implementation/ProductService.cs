using Api.Application.Services.Interfaces;
using Api.Domain.Dto.Request;
using Api.Domain.Repository;
using Api.Domain.UseCases.Product;

namespace Api.Application.Services.Implementation;

public class ProductService : IProductService
{
    private readonly IProductRepository _repository;
    private readonly ISupplierRepository _supplierRepository;

    public ProductService(IProductRepository repository, ISupplierRepository supplierRepository)
    {
        _repository = repository;
        _supplierRepository = supplierRepository;
    }

    public List<ProductDTO> FindAll()
    {
        FindProduct usecase = new FindProduct(_repository);

        return usecase.Execute();
    }

    public ProductDTO FindById(long id)
    {
        FindProduct usecase = new FindProduct(_repository);

        return usecase.Execute(id);
    }

    public ProductDTO Create(ProductDTO dto)
    {
        CreateProduct usecase = new CreateProduct(_repository, _supplierRepository);

        return usecase.Execute(dto);
    }

    public ProductDTO Update(ProductDTO dto)
    {
        UpdateProduct usecase = new UpdateProduct(_repository, _supplierRepository);

        return usecase.Execute(dto);
    }

    public void Delete(long id)
    {
        DeleteProduct usecase = new DeleteProduct(_repository);

        usecase.Execute(id);
    }
}

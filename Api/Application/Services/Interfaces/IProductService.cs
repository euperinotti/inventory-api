using Api.Domain.Dto.Request;

namespace Api.Application.Services.Interfaces;

public interface IProductService
{
    List<ProductDTO> FindAll();
    ProductDTO FindById(long id);
    ProductDTO Create(ProductDTO dto);
    ProductDTO Update(ProductDTO dto);
    void Delete(long id);
}

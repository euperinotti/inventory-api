using Api.Domain.Dto;

namespace Api.Application.Services.Interfaces;

public interface ISupplierService
{
    List<SupplierDTO> FindAll();
    SupplierDTO FindById(long id);
    SupplierDTO Create(SupplierDTO dto);
    SupplierDTO Update(SupplierDTO dto);
    void Delete(long id);
}

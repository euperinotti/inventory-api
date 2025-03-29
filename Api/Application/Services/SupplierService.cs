using Api.Domain.Dto;
using Api.Domain.Dto.Request;
using Api.Domain.Repository;
using Api.Domain.UseCases.Supplier;

namespace Api.Application.Services;

public class SupplierService
{
    private readonly ISupplierRepository _supplierRepository;

    public SupplierService(ISupplierRepository supplierRepository)
    {
        _supplierRepository = supplierRepository;
    }

    public SupplierDTO Update(SupplierDTO dto)
    {
        UpdateSupplier usecase = new UpdateSupplier(_supplierRepository);

        return usecase.Execute(dto);
    }

    public List<SupplierDTO> FindAll()
    {
        FindSupplier usecase = new FindSupplier(_supplierRepository);

        return usecase.Execute();
    }
}

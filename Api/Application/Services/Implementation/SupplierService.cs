using Api.Application.Services.Interfaces;
using Api.Domain.Dto;
using Api.Domain.Dto.Request;
using Api.Domain.Repository;
using Api.Domain.UseCases.Supplier;
using Api.Infra.Validators;

namespace Api.Application.Services.Implementation;

public class SupplierService : ISupplierService
{
    private readonly ISupplierRepository _supplierRepository;

    public SupplierService(ISupplierRepository supplierRepository)
    {
        _supplierRepository = supplierRepository;
    }

    public List<SupplierDTO> FindAll()
    {
        FindSupplier usecase = new FindSupplier(_supplierRepository);

        return usecase.Execute();
    }

    public SupplierDTO FindById(long id)
    {
        FindSupplier usecase = new FindSupplier(_supplierRepository);

        return usecase.Execute(id);
    }

    public SupplierDTO Create(SupplierDTO dto)
    {
        CreateSupplier usecase = new CreateSupplier(_supplierRepository);

        return usecase.Execute(dto);
    }

    public SupplierDTO Update(SupplierDTO dto)
    {
        UpdateSupplier usecase = new UpdateSupplier(_supplierRepository, new CnpjValidator());

        return usecase.Execute(dto);
    }

    public void Delete(long id)
    {
        DeleteSupplier usecase = new DeleteSupplier(_supplierRepository);

        usecase.Execute(id);
    }
}

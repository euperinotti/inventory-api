using InventoryApi.Domain.Dto;
using InventoryApi.Domain.Dto.Request;
using InventoryApi.Domain.Repository;
using InventoryApi.Domain.UseCases.Supplier;

namespace InventoryApi.Application.Services;

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

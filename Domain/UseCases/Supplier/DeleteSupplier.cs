using InventoryApi.Domain.Assertions;
using InventoryApi.Domain.Dto.Request;
using InventoryApi.Domain.Entities;
using InventoryApi.Domain.Mappers;
using InventoryApi.Domain.Repository;
using InventoryApi.Presentation.Dtos.Supplier;

namespace InventoryApi.Domain.UseCases.Supplier;

public class DeleteSupplier
{
    private readonly ISupplierRepository _repository;

    public DeleteSupplier(ISupplierRepository repository)
    {
        _repository = repository;
    }

    public void Execute(long supplierId)
    {
        SupplierBO bo = _repository.FindById((long) supplierId);

        Assert.IsNull(bo, "Supplier not found");

        _repository.Delete(supplierId);
    }

}

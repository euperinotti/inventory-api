using InventoryApi.Domain.Assertions;
using InventoryApi.Domain.Entities;
using InventoryApi.Domain.Repository;

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
        SupplierBO? bo = _repository.FindById(supplierId);
        Assert.IsNull(bo, "Supplier not found");

        _repository.Delete(supplierId);
    }

}

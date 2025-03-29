using Api.Domain.Assertions;
using Api.Domain.Entities;
using Api.Domain.Repository;

namespace Api.Domain.UseCases.Supplier;

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

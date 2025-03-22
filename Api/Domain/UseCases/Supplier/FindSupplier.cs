using InventoryApi.Domain.Assertions;
using InventoryApi.Domain.Dto;
using InventoryApi.Domain.Entities;
using InventoryApi.Domain.Mappers;
using InventoryApi.Domain.Repository;

namespace InventoryApi.Domain.UseCases.Supplier;

public class FindSupplier
{
    private readonly ISupplierRepository _repository;

    public FindSupplier(ISupplierRepository repository)
    {
        _repository = repository;
    }

    public List<SupplierDTO> Execute()
    {
        IEnumerable<SupplierBO> suppliers = _repository.FindAll();
        return suppliers.Select(SupplierMapper.ToDTO).ToList();
    }

    public SupplierDTO Execute(long supplierId)
    {
        SupplierBO? bo = _repository.FindById(supplierId);

        Assert.IsNull(bo, "Supplier not found");

        return SupplierMapper.ToDTO(bo!);
    }

    public SupplierDTO Execute(string cnpj)
    {
        SupplierBO? bo = _repository.FindByCnpj(cnpj);

        Assert.IsNull(bo, "Supplier not found");

        return SupplierMapper.ToDTO(bo!);
    }

}

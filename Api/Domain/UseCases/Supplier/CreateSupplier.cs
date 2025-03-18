using InventoryApi.Domain.Assertions;
using InventoryApi.Domain.Dto;
using InventoryApi.Domain.Entities;
using InventoryApi.Domain.Mappers;
using InventoryApi.Domain.Repository;

namespace InventoryApi.Domain.UseCases.Supplier;

public class CreateSupplier
{
    private readonly ISupplierRepository _repository;

    public CreateSupplier(ISupplierRepository repository)
    {
        _repository = repository;
    }

    public SupplierDTO Execute(SupplierDTO dto)
    {
        Validate(dto);
        SupplierBO bo = SupplierMapper.ToBO(dto);

        bo = _repository.Create(bo);

        return SupplierMapper.ToDTO(bo);
    }

    private void Validate(SupplierDTO dto)
    {
        SupplierBO? supplierBo = _repository.FindByCnpj(dto.Cnpj);
        Assert.IsNull(supplierBo, "Supplier already exists");
    }
}

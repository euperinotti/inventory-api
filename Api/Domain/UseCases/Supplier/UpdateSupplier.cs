using InventoryApi.Application.Validators;
using InventoryApi.Domain.Assertions;
using InventoryApi.Domain.Dto;
using InventoryApi.Domain.Dto.Request;
using InventoryApi.Domain.Entities;
using InventoryApi.Domain.Mappers;
using InventoryApi.Domain.Repository;
using InventoryApi.Presentation.Dtos.Supplier;

namespace InventoryApi.Domain.UseCases.Supplier;

public class UpdateSupplier
{
    private readonly ISupplierRepository _repository;

    public UpdateSupplier(ISupplierRepository repository)
    {
        _repository = repository;
    }

    public SupplierDTO Execute(SupplierDTO dto)
    {
        Validate(dto);
        SupplierBO bo = FindById((long) dto.Id);
        SupplierBO newBo = SupplierMapper.ToBO(dto);

        bo.UpdateSupplier(newBo);

        SupplierBO created = _repository.Create(bo);

        return SupplierMapper.ToDTO(created);
    }

    // TODO: Implement validate method
    private void Validate(SupplierDTO dto)
    {
        CnpjValidator cnpjValidator = new CnpjValidator();
        cnpjValidator.Validate(dto.Cnpj);
    }

    private SupplierBO FindById(long id)
    {
        SupplierBO? bo = _repository.FindById(id);
        Assert.IsNotNull(bo, "Supplier not found");

        return bo;
    }
}

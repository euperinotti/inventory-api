using Api.Domain.Assertions;
using Api.Domain.Dto;
using Api.Domain.Entities;
using Api.Domain.Mappers;
using Api.Domain.Repository;

namespace Api.Domain.UseCases.Supplier;

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

using Api.Application.Validators;
using Api.Domain.Assertions;
using Api.Domain.Dto;
using Api.Domain.Entities;
using Api.Domain.Mappers;
using Api.Domain.Repository;

namespace Api.Domain.UseCases.Supplier;

public class UpdateSupplier
{
    private readonly ISupplierRepository _repository;

    public UpdateSupplier(ISupplierRepository repository)
    {
        _repository = repository;
    }

    public SupplierDTO Execute(SupplierDTO dto)
    {
        SupplierBO bo = Validate(dto);
        SupplierBO newBo = SupplierMapper.ToBO(dto);

        bo.UpdateSupplier(newBo);

        SupplierBO created = _repository.Create(bo);

        return SupplierMapper.ToDTO(created);
    }

    private SupplierBO Validate(SupplierDTO dto)
    {
        CnpjValidator cnpjValidator = new CnpjValidator();
        cnpjValidator.Validate(dto.Cnpj);

        SupplierBO bo = FindById((long) dto.Id!);

        SupplierBO? existingSupplier = _repository.FindByCnpj(dto.Cnpj);

        if (existingSupplier != null && existingSupplier.Id != dto.Id)
        {
            throw new ArgumentException("A supplier with this CNPJ already exists.");
        }

        return bo;
    }

    private SupplierBO FindById(long id)
    {
        SupplierBO? bo = _repository.FindById(id);
        Assert.IsNotNull(bo, "Supplier not found");

        return bo!;
    }
}

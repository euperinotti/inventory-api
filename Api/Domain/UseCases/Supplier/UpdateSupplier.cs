using Api.Domain.Assertions;
using Api.Domain.Dto;
using Api.Domain.Entities;
using Api.Domain.Mappers;
using Api.Domain.Repository;
using Api.Domain.Validators;

namespace Api.Domain.UseCases.Supplier;

public class UpdateSupplier
{
    private readonly ISupplierRepository _repository;
    private readonly ICnpjValidator _cnpjValidator;

    public UpdateSupplier(ISupplierRepository repository, ICnpjValidator cnpjValidator)
    {
        _repository = repository;
        _cnpjValidator = cnpjValidator;
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
        _cnpjValidator.Validate(dto.Cnpj);

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

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

    public SupplierResponseDTO Execute(SupplierRequestDTO dto)
    {
        SupplierBO bo = SupplierMapper.ToBO(dto);

        SupplierBO created = _repository.Create(bo);

        return SupplierMapper.ToDTO(created);
    }

    // TODO: Implement validate method
    public void Validate(SupplierRequestDTO dto)
    {
        SupplierBO bo = _repository.FindById((long) dto.Id);
    }
}

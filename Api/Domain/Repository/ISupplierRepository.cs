using Api.Domain.Entities;

namespace Api.Domain.Repository;

public interface ISupplierRepository : ICrudRepository<SupplierBO, long>
{
    SupplierBO? FindByCnpj(string cnpj);
}

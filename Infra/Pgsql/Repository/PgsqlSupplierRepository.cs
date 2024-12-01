using inventory_api.Domain.Entities;
using inventory_api.Domain.Repository;

namespace inventory_api.Infra.Pgsql.Repository;

public class PgsqlSupplierRepository : ISupplierRepository
{
    public IEnumerable<SupplierBO> FindAll()
    {
        throw new NotImplementedException();
    }

    public SupplierBO? FindById(int id)
    {
        throw new NotImplementedException();
    }

    public SupplierBO Create(SupplierBO supplier)
    {
        throw new NotImplementedException();
    }

    public SupplierBO? Update(SupplierBO supplier)
    {
        throw new NotImplementedException();
    }

    public void Delete(SupplierBO supplier)
    {
        throw new NotImplementedException();
    }

    public void Delete(int? id)
    {
        throw new NotImplementedException();
    }
}
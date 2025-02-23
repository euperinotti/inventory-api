using InventoryApi.Domain.Entities;
using InventoryApi.Domain.Repository;

namespace InventoryApi.Infra.Pgsql.Repository;

public class PgSupplierRepository : ISupplierRepository
{
    public IEnumerable<SupplierBO> FindAll()
    {
        throw new NotImplementedException();
    }

    public SupplierBO? FindById(long id)
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

    public void Delete(long id)
    {
        throw new NotImplementedException();
    }

    public void Delete(int? id)
    {
        throw new NotImplementedException();
    }
}
using InventoryApi.Config;
using InventoryApi.Domain.Entities;
using InventoryApi.Domain.Repository;
using InventoryApi.Infra.Persistence.Pgsql.Mappers;
using InventoryApi.Infra.Pgsql.Entities;

namespace InventoryApi.Infra.Persistence.Pgsql.Repository;

public class PgSupplierRepository : ISupplierRepository
{
    private readonly PostgresDbContext _context;

    public PgSupplierRepository(PostgresDbContext context)
    {
        _context = context;
    }

    public IEnumerable<SupplierBO> FindAll()
    {
        IEnumerable<PgSupplierEntity> entities = _context.Suppliers.ToList();
        return entities.Select(PgSupplierMapper.ToBO);
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

    public SupplierBO? FindByCnpj(string cnpj)
    {
        throw new NotImplementedException();
    }
}

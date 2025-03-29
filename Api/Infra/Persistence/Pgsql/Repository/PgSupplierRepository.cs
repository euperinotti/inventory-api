using Api.Config;
using Api.Domain.Entities;
using Api.Domain.Repository;
using Api.Infra.Persistence.Pgsql.Mappers;
using Api.Infra.Pgsql.Entities;

namespace Api.Infra.Persistence.Pgsql.Repository;

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
        PgSupplierEntity? entity = _context.Suppliers.FirstOrDefault(e => e.Id == id);
        return entity == null ? null : PgSupplierMapper.ToBO(entity);
    }

    public SupplierBO Create(SupplierBO supplier)
    {
        PgSupplierEntity entity = PgSupplierMapper.ToEntity(supplier);
        _context.Suppliers.Add(entity);
        _context.SaveChanges();
        return PgSupplierMapper.ToBO(entity);
    }

    public SupplierBO? Update(SupplierBO supplier)
    {
        PgSupplierEntity entity = PgSupplierMapper.ToEntity(supplier);
        _context.Suppliers.Update(entity);
        _context.SaveChanges();
        return PgSupplierMapper.ToBO(entity);
    }

    public void Delete(SupplierBO supplier)
    {
        PgSupplierEntity entity = PgSupplierMapper.ToEntity(supplier);
        bool exists = _context.Suppliers.Any(item => item.Equals(entity));

        if (!exists) return;

        _context.Suppliers.Remove(entity);
        _context.SaveChanges();
    }

    public void Delete(long id)
    {
        SupplierBO? bo = FindById(id);

        if (bo == null) return;

        Delete(bo);
    }

    public SupplierBO? FindByCnpj(string cnpj)
    {
        PgSupplierEntity entity = _context.Suppliers.FirstOrDefault(item => item.Cnpj.Equals(cnpj));
        return entity == null ? null : PgSupplierMapper.ToBO(entity);
    }
}

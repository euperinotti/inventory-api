using Api.Domain.Entities;
using Api.Domain.Repository;
using Api.Infra.Persistence.Pgsql.Config;
using Api.Infra.Persistence.Pgsql.Entities;
using Api.Infra.Persistence.Pgsql.Mappers;

namespace Api.Infra.Persistence.Pgsql.Repository;

public class PgProductRepository : IProductRepository
{
    private readonly PostgresDbContext _context;

    public PgProductRepository(PostgresDbContext context)
    {
        _context = context;
    }

    public IEnumerable<ProductBO> FindAll()
    {
        IEnumerable<PgProductEntity> entities = _context.Products.ToList();
        return entities.Select(PgProductMapper.ToBO);
    }

    public ProductBO? FindById(long id)
    {
        PgProductEntity? entity = _context.Products.FirstOrDefault(e => e.Id == id);
        return entity == null ? null : PgProductMapper.ToBO(entity);
    }

    public ProductBO Create(ProductBO supplier)
    {
        PgProductEntity entity = PgProductMapper.ToEntity(supplier);
        _context.Products.Add(entity);
        _context.SaveChanges();
        return PgProductMapper.ToBO(entity);
    }

    public ProductBO? Update(ProductBO supplier)
    {
        PgProductEntity entity = PgProductMapper.ToEntity(supplier);
        _context.Products.Update(entity);
        _context.SaveChanges();
        return PgProductMapper.ToBO(entity);
    }

    public void Delete(ProductBO supplier)
    {
        PgProductEntity entity = PgProductMapper.ToEntity(supplier);
        bool exists = _context.Products.Any(item => item.Equals(entity));

        if (!exists) return;

        _context.Products.Remove(entity);
        _context.SaveChanges();
    }

    public void Delete(long id)
    {
        ProductBO? bo = FindById(id);

        if (bo == null) return;

        Delete(bo);
    }
}

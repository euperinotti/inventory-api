using Api.Domain.Entities;
using Api.Infra.Persistence.Pgsql.Entities;

namespace Api.Infra.Persistence.Pgsql.Mappers;

public static class PgProductMapper
{
    public static PgProductEntity ToEntity(ProductBO bo)
    {
        return new PgProductEntity(bo.Id, bo.Name, bo.Description, bo.Price, bo.Quantity, bo.ImageURL,
            PgSupplierMapper.ToEntity(bo.Supplier),
            bo.CreatedAt, bo.UpdatedAt);
    }

    public static ProductBO ToBO(PgProductEntity entity)
    {
        return new ProductBO(entity.Id, entity.Name, entity.Description, entity.Price, entity.Quantity, entity.ImageURL,
            PgSupplierMapper.ToBO(entity.Supplier));
    }
}

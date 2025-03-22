using InventoryApi.Domain.Dto.Request;
using InventoryApi.Domain.Entities;
using InventoryApi.Infra.Pgsql.Entities;

namespace InventoryApi.Infra.Persistence.Pgsql.Mappers;

public static class PgSupplierMapper
{
    public static PgSupplierEntity ToEntity(SupplierBO bo)
    {
        PgSupplierEntity entity = new PgSupplierEntity();
        entity.Id = bo.Id;
        entity.CreatedAt = bo.CreatedAt;
        entity.UpdatedAt = bo.UpdatedAt;
        entity.Name = bo.Name;
        entity.Cnpj = bo.Cnpj;
        entity.Address = bo.Address;
        entity.Contact = bo.Contact;

        return entity;
    }

    public static SupplierBO ToBO(PgSupplierEntity entity)
    {
        return new SupplierBO(entity.Id, entity.Name, entity.Cnpj, entity.Address, entity.Contact, entity.CreatedAt, entity.UpdatedAt);
    }
}

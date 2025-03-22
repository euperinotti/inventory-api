using InventoryApi.Infra.Pgsql.Entities;
using Microsoft.EntityFrameworkCore;

namespace InventoryApi.Config;

public class PostgresDbContext : DbContext
{
    public PostgresDbContext(DbContextOptions options) : base(options) {}

    public DbSet<PgSupplierEntity> Suppliers { get; set; }
}

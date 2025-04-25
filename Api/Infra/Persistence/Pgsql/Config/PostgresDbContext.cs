using Api.Infra.Pgsql.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Infra.Persistence.Pgsql.Config;

public class PostgresDbContext : DbContext
{
    public PostgresDbContext(DbContextOptions options) : base(options) {}

    public DbSet<PgSupplierEntity> Suppliers { get; set; }
}

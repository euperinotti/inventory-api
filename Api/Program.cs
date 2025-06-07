using Api.Application.Services.Implementation;
using Api.Application.Services.Interfaces;
using Api.Config.Middlewares;
using Api.Domain.Repository;
using Api.Infra.Persistence.Pgsql.Config;
using Api.Infra.Persistence.Pgsql.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<PostgresDbContext>();
builder.Services.AddDbContext<PostgresDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<ISupplierService, SupplierService>();
builder.Services.AddScoped<ISupplierRepository, PgSupplierRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, PgProductRepository>();

AuthenticationMiddleware authenticationMiddleware = new AuthenticationMiddleware();
authenticationMiddleware.Configure(builder.Services, builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();

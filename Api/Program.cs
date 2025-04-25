using Api.Config.Middlewares;
using Api.Infra.Persistence.Pgsql.Config;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<PostgresDbContext>();
builder.Services.AddDbContext<PostgresDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

AuthenticationMiddleware authenticationMiddleware = new AuthenticationMiddleware();
authenticationMiddleware.Configure(builder.Services, builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();

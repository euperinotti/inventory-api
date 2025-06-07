using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Api.Infra.Pgsql.Entities;

namespace Api.Infra.Persistence.Pgsql.Entities;

[Table("products")]
public class PgProductEntity
{
    [Key] public long? Id { get; private set; }

    [MaxLength(200)]
    public string Name { get; private set; }

    [MaxLength(500)]
    public string Description { get; private set; }
    public decimal Price { get; private set; }
    public int Quantity { get; private set; }
    public string ImageURL { get; private set; }
    public PgSupplierEntity Supplier { get; private set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public PgProductEntity(long? id, string name, string description, decimal price, int quantity, string imageUrl,
        PgSupplierEntity supplier, DateTime createdAt, DateTime updatedAt)
    {
        Id = id;
        Name = name;
        Description = description;
        Price = price;
        Quantity = quantity;
        ImageURL = imageUrl;
        Supplier = supplier;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public PgProductEntity()
    {
    }
}

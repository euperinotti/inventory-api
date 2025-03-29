using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Infra.Pgsql.Entities;

[Table("suppliers")]
public class PgSupplierEntity
{
    [Key] public long? Id { get; set; }
    public string Name { get; set; }
    public string Cnpj { get; set; }
    public string Contact { get; set; }
    public string Address { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public PgSupplierEntity(long? id, string name, string cnpj, string contact, string address, DateTime createdAt, DateTime updatedAt)
    {
        this.Id = id;
        this.Name = name;
        this.Cnpj = cnpj;
        this.Contact = contact;
        this.Address = address;
        this.CreatedAt = createdAt;
        this.UpdatedAt = updatedAt;
    }

    public PgSupplierEntity()
    {
    }
}

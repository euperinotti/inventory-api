using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryApi.Infra.Pgsql.Entities;

[Table("suppliers")]
public class PgSupplierEntity
{
    [Key] public long? id { get; private set; }
    public string name { get; private set; }
    public string cnpj { get; private set; }
    public string contact { get; private set; }
    public string address { get; private set; }

    public PgSupplierEntity(long? id, string name, string cnpj, string contact, string address)
    {
        this.id = id;
        this.name = name;
        this.cnpj = cnpj;
        this.contact = contact;
        this.address = address;
    }

}

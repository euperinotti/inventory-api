using System;
using InventoryApi.Domain.Assertions;

namespace InventoryApi.Domain.Entities;
public class SupplierBO : AbstractEntityBO
{
    public string Name { get; private set; }
    public string Cnpj { get; private set; }
    public string Address { get; private set; }
    public string Contact { get; private set; }

    public SupplierBO(long? id, string name, string cnpj, string address, string contact, DateTime createdAt, DateTime updatedAt) :
        base(id, createdAt, updatedAt)
    {
        Name = name;
        Cnpj = cnpj;
        Address = address;
        Contact = contact;

        Validate();
    }

    private void Validate()
    {
        Assert.IsNullOrWhiteSpace(Name, "Supplier name is required");
        Assert.IsNullOrWhiteSpace(Contact, "Supplier contact is required");
        Assert.IsNullOrWhiteSpace(Cnpj, "Supplier CNPJ is required");
    }
}
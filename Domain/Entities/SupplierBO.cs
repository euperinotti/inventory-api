using System;
namespace inventory_api.Domain.Entities;
public class SupplierBO
{
    public long? Id { get; private set; }
    public string Name { get; private set; }
    public string Cnpj { get; private set; }
    public string Address { get; private set; }
    public string Contact { get; private set; }

    public SupplierBO(long? id, string name, string cnpj, string address, string contact)
    {
        Id = id;
        Name = name;
        Cnpj = cnpj;
        Address = address;
        Contact = contact;

        Validate();
    }

    private void Validate()
    {
        if (string.IsNullOrWhiteSpace(Name))
        {
            throw new ArgumentException("Supplier name is required");
        }

        if (string.IsNullOrWhiteSpace(Cnpj))
        {
            throw new ArgumentException("Supplier CNPJ is required");
        }
    }
}
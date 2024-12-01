using System;
namespace inventory_api.Domain.Entities;

// ReSharper disable once InconsistentNaming
public class SupplierBO
{
    public long? Id { get; set; }
    public string Name { get; set; }
    public string Cnpj { get; set; }
    public string Address { get; set; }
    public string Contact { get; set; }

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
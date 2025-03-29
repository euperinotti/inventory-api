using System;
using Api.Domain.Assertions;

namespace Api.Domain.Entities;
public class SupplierBO : AbstractEntityBO<long?>
{
    private string _name;
    private string _cnpj;
    private string _address;
    private string _contact;

    public SupplierBO(long? id, string name, string cnpj, string address, string contact, DateTime createdAt, DateTime updatedAt) :
        base(id, createdAt, updatedAt)
    {
        Name = name;
        Cnpj = cnpj;
        Address = address;
        Contact = contact;

        Validate();
    }

    public string Name
    {
        get => _name;
        private set => _name = value;
    }

    public string Cnpj
    {
        get => _cnpj;
        private set => _cnpj = value;
    }

    public string Address
    {
        get => _address;
        private set => _address = value;
    }

    public string Contact
    {
        get => _contact;
        private set => _contact = value;
    }

    private void Validate()
    {
        Assert.IsNullOrWhiteSpace(Name, "Supplier name is required");
        Assert.IsNullOrWhiteSpace(Contact, "Supplier contact is required");
        Assert.IsNullOrWhiteSpace(Cnpj, "Supplier CNPJ is required");
    }

    public void UpdateSupplier(SupplierBO bo)
    {
        Name = bo.Name;
        Cnpj = bo.Cnpj;
        Address = bo.Address;
        Contact = bo.Contact;

        Validate();
    }
}

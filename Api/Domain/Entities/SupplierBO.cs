using System;
using Api.Domain.Assertions;
using Api.Infra.Validators;

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
        Assert.IsNotNullOrWhiteSpace(Name, "Supplier name is required");
        Assert.IsNotNullOrWhiteSpace(Contact, "Supplier contact is required");
        Assert.IsNotNullOrWhiteSpace(Cnpj, "Supplier CNPJ is required");

        CnpjValidator cnpjValidator = new CnpjValidator();
        cnpjValidator.Validate(Cnpj);
    }

    public void Update(SupplierBO bo)
    {
        Name = bo.Name;
        Cnpj = bo.Cnpj;
        Address = bo.Address;
        Contact = bo.Contact;

        Validate();
    }
}

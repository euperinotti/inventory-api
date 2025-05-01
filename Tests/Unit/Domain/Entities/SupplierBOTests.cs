using Api.Domain.Entities;
using Api.Domain.Exceptions;
using Tests.Unit.Domain.Assertions;

namespace Tests.Unit.Domain.Entities;

public class SupplierBOTests
{
    [Test]
    public void Constructor_ShouldThrowIfNameIsNull()
    {
        Assert.Throws<AssertException>(() =>
        {
            new SupplierBO(1, null, "100", "Address", "Contact", DateTime.Now, DateTime.Now);
        });
    }

    [Test]
    public void Constructor_ShouldThrowIfNameIsWhiteSpace()
    {
        Assert.Throws<AssertException>(() =>
        {
            new SupplierBO(1, "    ", "100", "Address", "Contact", DateTime.Now, DateTime.Now);
        });
    }

    [Test]
    public void Constructor_ShouldThrowIfCnpjIsNull()
    {
        Assert.Throws<AssertException>(() =>
        {
            new SupplierBO(1, "Eric Kong", null, "Address", "Contact", DateTime.Now, DateTime.Now);
        });
    }

    [Test]
    public void Constructor_ShouldThrowIfCnpjIsWhiteSpace()
    {
        Assert.Throws<AssertException>(() =>
        {
            new SupplierBO(1, "Eric Kong", "", "Address", "Contact", DateTime.Now, DateTime.Now);
        });
    }

    [Test]
    public void Constructor_ShouldThrowIfContactIsNull()
    {
        Assert.Throws<AssertException>(() =>
        {
            new SupplierBO(1, "Eric Kong", "61264680887", "Address", null, DateTime.Now, DateTime.Now);
        });
    }

    [Test]
    public void Constructor_ShouldThrowIfContactIsWhiteSpace()
    {
        Assert.Throws<AssertException>(() =>
        {
            new SupplierBO(1, "Eric Kong", "61264680887", "Address", "     ", DateTime.Now, DateTime.Now);
        });
    }

    [Test]
    public void Constructor_ShouldThrowIfCnpjHasInvalidFormat()
    {
        Assert.Throws<ValidationException>(() =>
        {
            new SupplierBO(1, "Eric Kong", "61264680887", "Address", "nlc6pocdlnk@gmail.com", DateTime.Now, DateTime.Now);
        });
    }

    [Test]
    public void Constructor_ShouldThrowIfCnpjIsInvalid()
    {
        Assert.Throws<ValidationException>(() =>
        {
            new SupplierBO(1, "Eric Kong", "61264680887111", "Address", "nlc6pocdlnk@gmail.com", DateTime.Now, DateTime.Now);
        });
    }

    [Test]
    public void Constructor_ShouldCreateClassInstanceCorrectly()
    {
        Assert.DoesNotThrow(() =>
        {
            new SupplierBO(1, "Eric Kong", "48088429000109", "Address", "nlc6pocdlnk@gmail.com", DateTime.Now, DateTime.Now);
        });
    }

    [Test]
    public void Update_ShouldUpdateEntityFields()
    {
        SupplierBO supplier1 = new SupplierBO(1, "Eric Kong", "39875718000167", "Address", "nlc6pocdlnk@gmail.com", DateTime.Now, DateTime.Now.AddDays(-1));
        SupplierBO supplier2 = new SupplierBO(2, "MamadouTao", "48088429000109", "Address", "kv5sp2vkhpu@gmail.com", DateTime.Now, DateTime.Now);

        supplier1.Update(supplier2);

        Assert.That(supplier2.Name, Is.EqualTo(supplier1.Name));
        Assert.That(supplier2.Cnpj, Is.EqualTo(supplier1.Cnpj));
        Assert.That(supplier2.Address, Is.EqualTo(supplier1.Address));
        Assert.That(supplier2.Contact, Is.EqualTo(supplier1.Contact));
        Assert.That(DateTime.Now.Day, Is.EqualTo(supplier1.UpdatedAt.Day));
    }
}

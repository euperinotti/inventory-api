using Api.Domain.Entities;
using Api.Domain.Exceptions;

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
}

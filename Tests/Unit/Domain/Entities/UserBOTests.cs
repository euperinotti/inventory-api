using Api.Domain.Entities;
using Api.Domain.Exceptions;

namespace Tests.Unit.Domain.Entities;

public class UserBOTests
{
    [Test]
    public void Constructor_ShouldThrowIfEmailIsNull()
    {
        Assert.Throws<AssertException>(() =>
        {
            new UserBO(1, "Eric Kong", null, "123", DateTime.Now, DateTime.Now);
        });
    }

    [Test]
    public void Constructor_ShouldThrowIfEmailIsWhiteSpace()
    {
        Assert.Throws<AssertException>(() =>
        {
            new UserBO(1, "Eric Kong", "     ", "123", DateTime.Now, DateTime.Now);
        });
    }

    [Test]
    public void Constructor_ShouldThrowIfPasswordIsNull()
    {
        Assert.Throws<AssertException>(() =>
        {
            new UserBO(1, "Eric Kong", "123", null, DateTime.Now, DateTime.Now);
        });
    }

    [Test]
    public void Constructor_ShouldThrowIfPasswordIsWhiteSpace()
    {
        Assert.Throws<AssertException>(() =>
        {
            new UserBO(1, "Eric Kong", "123", "     ", DateTime.Now, DateTime.Now);
        });
    }

    [Test]
    public void Constructor_ShouldThrowIfNameIsNull()
    {
        Assert.Throws<AssertException>(() =>
        {
            new UserBO(1, null, "123", "123", DateTime.Now, DateTime.Now);
        });
    }

    [Test]
    public void Constructor_ShouldThrowIfNameIsWhiteSpace()
    {
        Assert.Throws<AssertException>(() =>
        {
            new UserBO(1, "     ", "123", "123", DateTime.Now, DateTime.Now);
        });
    }

}

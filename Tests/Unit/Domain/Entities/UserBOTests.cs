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

    [Test]
    public void Constructor_ShouldThrowIfPasswordHasInvalidLength()
    {
        Assert.Throws<AssertException>(() =>
        {
            new UserBO(1, "Jianguo Jones", "123", "123", DateTime.Now, DateTime.Now);
        });
    }

    [Test]
    public void Constructor_ShouldThrowIfPasswordDoesntHaveUppercase()
    {
        Assert.Throws<ValidationException>(() =>
        {
            new UserBO(1, "Jianguo Jones", "123", "abcdefgh", DateTime.Now, DateTime.Now);
        });
    }

    [Test]
    public void Constructor_ShouldThrowIfPasswordDoesntHaveLowercase()
    {
        Assert.Throws<ValidationException>(() =>
        {
            new UserBO(1, "Jianguo Jones", "123", "ABCDEFGH", DateTime.Now, DateTime.Now);
        });
    }

    [Test]
    public void Constructor_ShouldThrowIfPasswordDoesntHaveDigit()
    {
        Assert.Throws<ValidationException>(() =>
        {
            new UserBO(1, "Jianguo Jones", "123", "abcDEFGH", DateTime.Now, DateTime.Now);
        });
    }

    [Test]
    public void Constructor_ShouldThrowIfPasswordDoesntHaveSpecialCharacter()
    {
        Assert.Throws<ValidationException>(() =>
        {
            new UserBO(1, "Jianguo Jones", "123", "abcDEFGH1", DateTime.Now, DateTime.Now);
        });
    }

    [Test]
    public void Constructor_ShouldCreateClassInstanceCorrectly()
    {
        Assert.DoesNotThrow(() =>
        {
            new UserBO(1, "Eric Kong", "123", "abcDEFGH1!", DateTime.Now, DateTime.Now);
        });
    }
}

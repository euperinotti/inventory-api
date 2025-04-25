using Api.Domain.Exceptions;
using DomainAssert = Api.Domain.Assertions.Assert;

namespace Tests.Unit.Domain.Assertions;

public class AssertTest
{
    [Test]
    public void IsNull_ShouldNotThrowWhenObjectIsNull()
    {
        object obj1 = null;

        Assert.DoesNotThrow(() =>
        {
            DomainAssert.IsNull(obj1, "Object must be null");
        });
    }

    [Test]
    public void IsNull_ShouldThrowWhenObjectIsNotNull()
    {
        object obj1 = new string("hello");

        Assert.Throws<AssertException>(() =>
        {
            DomainAssert.IsNull(obj1, "Object must be null");
        });
    }

    [Test]
    public void IsNotNull_ShouldNotThrowWhenObjectIsNotNull()
    {
        object obj1 = new string("hello");

        Assert.DoesNotThrow(() =>
        {
            DomainAssert.IsNotNull(obj1, "Object must not be null");
        });
    }

    [Test]
    public void IsNotNull_ShouldThrowWhenObjectIsNotNull()
    {
        object obj1 = null;

        Assert.Throws<AssertException>(() =>
        {
            DomainAssert.IsNotNull(obj1, "Object must not be null");
        });
    }

    [Test]
    public void IsTrue_ShouldNotThrowWhenConditionIsTrue()
    {
        Assert.DoesNotThrow(() =>
        {
            DomainAssert.IsTrue(1 == 1, "Condition must be true");
        });
    }

    [Test]
    public void IsTrue_ShouldThrowWhenConditionIsNotTrue()
    {
        Assert.Throws<AssertException>(() =>
        {
            DomainAssert.IsTrue(1 == 2, "Condition must be true");
        });
    }

    [Test]
    public void IsFalse_ShouldNotThrowWhenConditionIsFalse()
    {
        Assert.DoesNotThrow(() =>
        {
            DomainAssert.IsFalse(1 != 1, "Condition must be false");
        });
    }

    [Test]
    public void IsFalse_ShouldThrowWhenConditionIsNotFalse()
    {
        Assert.Throws<AssertException>(() =>
        {
            DomainAssert.IsFalse(1 == 1, "Condition must be true");
        });
    }
}

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

    [Test]
    public void IsNullOrEmpty_ShouldNotThrowWhenValueIsNullOrEmpty()
    {
        string value = null;
        Assert.DoesNotThrow(() =>
        {
            DomainAssert.IsNullOrEmpty(value, "Value must be null or an empty string");
        });
    }

    [Test]
    public void IsNullOrEmpty_ShouldThrowWhenValueIsNotNullOrEmpty()
    {
        string value = "string";
        Assert.Throws<AssertException>(() =>
        {
            DomainAssert.IsNullOrEmpty(value, "Value must be null or an empty string");
        });
    }

    [Test]
    public void IsNullOrWhiteSpace_ShouldNotThrowWhenValueIsNull()
    {
        string value = null;
        Assert.DoesNotThrow(() =>
        {
            DomainAssert.IsNullOrWhiteSpace(value, "Value must be null or a white spaced string");
        });
    }

    [Test]
    public void IsNullOrWhiteSpace_ShouldNotThrowWhenValueIsWhiteSpace()
    {
        string value = "      ";
        Assert.DoesNotThrow(() =>
        {
            DomainAssert.IsNullOrWhiteSpace(value, "Value must be null or a white spaced string");
        });
    }

    [Test]
    public void IsNullOrWhiteSpace_ShouldThrowWhenValueIsNotNullOrWhiteSpace()
    {
        string value = "string";
        Assert.Throws<AssertException>(() =>
        {
            DomainAssert.IsNullOrWhiteSpace(value, "Value must be null or a white spaced string");
        });
    }

    [Test]
    public void IsGreaterThan_ShouldNotThrowWhenValueIsGreaterThanTheOtherValue()
    {
        Assert.DoesNotThrow(() =>
        {
            DomainAssert.IsGreaterThan(20, 10, "Value 2 must be grater than value 1");
        });
    }

    [Test]
    public void IsGreaterThan_ShouldThrowWhenValuesAreEqual()
    {
        Assert.Throws<AssertException>(() =>
        {
            DomainAssert.IsGreaterThan(10, 10, "Value 2 must be grater than value 1");
        });
    }

    [Test]
    public void IsGreaterThan_ShouldThrowWhenValueIsLessThanTheOtherValue()
    {
        Assert.Throws<AssertException>(() =>
        {
            DomainAssert.IsGreaterThan(5, 10, "Value 2 must be grater than value 1");
        });
    }

}

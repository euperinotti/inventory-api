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
}

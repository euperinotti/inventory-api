using Api.Domain;
using Api.Domain.Entities;

namespace Tests.Unit.Domain.Entities;

public class OrderBOTests
{
    [Test]
    public void Constructor_ShouldThrowIfSupplierIsNull()
    {
        Assert.Throws<ArgumentNullException>(() =>
        {
            new OrderBO(1, DateTime.Now, OrderStatus.Pending, new List<OrderItemBO>(), 0, null, DateTime.Now, DateTime.Now);
        });
    }

    [Test]
    public void Constructor_ShouldThrowIfTotalIsLowerThanZero()
    {
        SupplierBO supplier = new SupplierBO(1, "Name", "100", "Address", "Contact", DateTime.Now, DateTime.Now);

        Assert.Throws<ArgumentException>(() =>
        {
            new OrderBO(1, DateTime.Now, OrderStatus.Pending, new List<OrderItemBO>(), -10, supplier, DateTime.Now, DateTime.Now);
        });
    }
}

using Api.Domain.Entities;
using Api.Domain.Enums;
using Api.Domain.Exceptions;

namespace Tests.Unit.Domain.Entities;

public class OrderBOTests
{
    [Test]
    public void Constructor_ShouldThrowIfSupplierIsNull()
    {
        Assert.Throws<AssertException>(() =>
        {
            new OrderBO(1, OrderStatus.Pending, new List<OrderItemBO>(), 0, null, DateTime.Now, DateTime.Now);
        });
    }

    [Test]
    public void Constructor_ShouldThrowIfTotalIsLowerThanZero()
    {
        SupplierBO supplier = new SupplierBO(1, "Name", "39875718000167", "Address", "Contact", DateTime.Now, DateTime.Now);

        Assert.Throws<AssertException>(() =>
        {
            new OrderBO(1, OrderStatus.Pending, new List<OrderItemBO>(), -10, supplier, DateTime.Now, DateTime.Now);
        });
    }

    [Test]
    public void Constructor_ShouldThrowIfOrderIsCreatedInTheFuture()
    {
        SupplierBO supplier = new SupplierBO(1, "Name", "39875718000167", "Address", "Contact", DateTime.Now, DateTime.Now);

        Assert.Throws<AssertException>(() =>
        {
            new OrderBO(1, OrderStatus.Pending, new List<OrderItemBO>(), 10, supplier, DateTime.Now.AddDays(5), DateTime.Now);
        });
    }

    [Test]
    public void Constructor_ShouldCreateOrder()
    {
        SupplierBO supplier = new SupplierBO(1, "Name", "39875718000167", "Address", "Contact", DateTime.Now, DateTime.Now);

        Assert.DoesNotThrow(() =>
        {
            new OrderBO(1, OrderStatus.Pending, new List<OrderItemBO>(), 10, supplier, DateTime.Now, DateTime.Now);
        });
    }

    [Test]
    public void UpdateOrder_ShouldUpdateOrder()
    {
        SupplierBO supplier = new SupplierBO(1, "Name", "39875718000167", "Address", "Contact", DateTime.Now, DateTime.Now);
        ProductBO product = new ProductBO(1, "Product", "Description", 10, 1000, "https://image.com", supplier);
        OrderBO order = new OrderBO(1, OrderStatus.Pending, new List<OrderItemBO>(), 10, supplier, DateTime.Now, DateTime.Now);

        List<OrderItemBO> list = new List<OrderItemBO>()
        {
            new OrderItemBO(1, product, order, 1, 10),
            new OrderItemBO(2, product, order, 5, 10)
        };

        order.UpdateOrder(OrderStatus.Done, list);

        Assert.That(order.Status, Is.EqualTo(OrderStatus.Done));
        Assert.That(order.Items.Count, Is.EqualTo(2));
        Assert.That(order.Total, Is.EqualTo(60));
    }

    [Test]
    public void AddItem_ShouldAddNewItemToOrder()
    {
        SupplierBO supplier = new SupplierBO(1, "Name", "39875718000167", "Address", "Contact", DateTime.Now, DateTime.Now);
        ProductBO product = new ProductBO(1, "Product", "Description", 10, 1000, "https://image.com", supplier);
        ProductBO product2 = new ProductBO(2, "Product2", "Description", 10, 1000, "https://image.com", supplier);
        OrderBO order = new OrderBO(1, OrderStatus.Pending, new List<OrderItemBO>(), 10, supplier, DateTime.Now, DateTime.Now);

        List<OrderItemBO> list = new List<OrderItemBO>()
        {
            new OrderItemBO(1, product, order, 1, 10),
            new OrderItemBO(2, product, order, 5, 10)
        };

        order.UpdateOrder(OrderStatus.Done, list);

        OrderItemBO item = new OrderItemBO(3, product2, order, 5, 10);

        order.AddItem(item);

        Assert.That(order.Items.Count, Is.EqualTo(3));
    }

    [Test]
    public void AddItem_ShouldIncreaseIfItemIsAlreadyOnOrder()
    {
        SupplierBO supplier = new SupplierBO(1, "Name", "39875718000167", "Address", "Contact", DateTime.Now, DateTime.Now);
        ProductBO product = new ProductBO(1, "Product", "Description", 10, 1000, "https://image.com", supplier);
        OrderBO order = new OrderBO(1, OrderStatus.Pending, new List<OrderItemBO>(), 10, supplier, DateTime.Now, DateTime.Now);
        List<OrderItemBO> list = new List<OrderItemBO>()
        {
            new OrderItemBO(1, product, order, 1, 10),
            new OrderItemBO(2, product, order, 5, 10)
        };

        order.UpdateOrder(OrderStatus.Done, list);

        order.AddItem(product);

        Assert.That(order.Items.Count, Is.EqualTo(3));
    }
}

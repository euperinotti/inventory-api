using Api.Domain.Entities;

namespace Api.Domain.UseCases.Order;

public class CalculateAmount
{
    public decimal Execute(List<OrderItemBO> orderItems)
    {
        decimal total = 0;

        foreach (OrderItemBO item in orderItems)
        {
            total += item.Quantity * item.UnitPrice;
        }

        return total;
    }
}

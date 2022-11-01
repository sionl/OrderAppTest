using Domain.Models;

namespace Domain
{
    public interface IPriceCalculator
    {
        decimal GetPrice(Order order);
    }
}

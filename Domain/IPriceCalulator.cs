using Domain.Models;

namespace Domain
{
    public interface IPriceCalulator
    {
        decimal GetPrice(Order order);
    }
}

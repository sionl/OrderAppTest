using System.Dynamic;
using Domain.Models;

namespace Domain
{
    public class PriceCalulator : IPriceCalulator
    {
        private const decimal BOOK_PRICE = 8;

        private const decimal TWO_BOOK_SET = 5;
        private const decimal THREE_BOOK_SET = 10;
        private const decimal FOUR_BOOK_SET = 20;
        private const decimal FIVE_BOOK_SET = 25;


        public decimal GetPrice(Order order)
        {
            var orderTotal = (order.First + order.Second + order.Third + order.Fourth + order.Firth) * BOOK_PRICE;

            var discountPercentage = GetDiscoundLevel(order);
            if (discountPercentage > 0)
            {
                var discount = orderTotal / 100 * discountPercentage;
                orderTotal -= discount;
            }

            return orderTotal;
        }

        private decimal GetDiscoundLevel(Order order)
        {
            var list = new List<int> { order.First, order.Second, order.Third, order.Fourth, order.Firth };
            var sets = list.Where(x => x != 0).Count();

            if (sets == 5)
            {
                return FIVE_BOOK_SET;
            }

            if (sets == 4)
            {
                return FOUR_BOOK_SET;
            }

            if (sets == 3)
            {
                return THREE_BOOK_SET;
            }

            if (sets == 2)
            {
                return TWO_BOOK_SET;
            }

            return 0;
        }
    }
}
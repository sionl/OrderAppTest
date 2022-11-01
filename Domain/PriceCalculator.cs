using Domain.Models;

namespace Domain
{
    public class PriceCalculator : IPriceCalculator
    {
        private const decimal BOOK_PRICE = 8;

        private const decimal TWO_BOOK_DISCOUNT = 5;
        private const decimal THREE_BOOK_DISCOUNT = 10;
        private const decimal FOUR_BOOK_DISCOUNT = 20;
        private const decimal FIVE_BOOK_DISCOUNT = 25;

        public decimal GetPrice(Order order)
        {
            decimal orderTotal = 0;

            var remainingOrder = order;
            var discount = GetDiscount(remainingOrder);
            while (discount.Rate > 0)
            {
                decimal price = discount.Sets * discount.CompleteSets * BOOK_PRICE;
                decimal discountAmount = price / 100 * discount.Rate;
                orderTotal = orderTotal + price - discountAmount;
                remainingOrder = OrderAfterDiscount(remainingOrder, discount);
                discount = GetDiscount(remainingOrder);
            }

            orderTotal += (remainingOrder.First + remainingOrder.Second + remainingOrder.Third + remainingOrder.Fourth + remainingOrder.Firth) * BOOK_PRICE;

            return orderTotal;
        }

        private Discount GetDiscount(Order order)
        {
            var discount = new Discount();
            var list = new List<int> { order.First, order.Second, order.Third, order.Fourth, order.Firth };
            var sets = list.Where(x => x != 0).Count();

            if (sets > 0)
            {
                discount.Sets = sets;
                discount.CompleteSets = list.Where(x => x != 0).Min();
                discount.Rate = GetDiscountRate(sets);
            }

            return discount;
        }

        private decimal GetDiscountRate(int sets)
        {
            if (sets == 5)
            {
                return FIVE_BOOK_DISCOUNT;
            }

            if (sets == 4)
            {
                return FOUR_BOOK_DISCOUNT;
            }

            if (sets == 3)
            {
                return THREE_BOOK_DISCOUNT;
            }

            if (sets == 2)
            {
                return TWO_BOOK_DISCOUNT;
            }

            return 0;
        }

        private Order OrderAfterDiscount(Order order, Discount discount)
        {
            if (order.First > 0)
            {
                order.First -= discount.CompleteSets;
            }

            if (order.Second > 0)
            {
                order.Second -= discount.CompleteSets;
            }

            if (order.Third > 0)
            {
                order.Third -= discount.CompleteSets;
            }

            if (order.Fourth > 0)
            {
                order.Fourth -= discount.CompleteSets;
            }

            if (order.Firth > 0)
            {
                order.Firth -= discount.CompleteSets;
            }

            return order;
        }
    }
}
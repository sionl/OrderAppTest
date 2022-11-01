using Domain;
using Domain.Models;

namespace Tests.PriceCalulatorTests
{
    [TestClass]
    public class PriceCalculator_GetPrice
    {
        private PriceCalculator priceCalulator = new PriceCalculator();

        [TestMethod]
        public void WhenNoBookes_Expect0()
        {
            var order = new Order();
            var actual = priceCalulator.GetPrice(order);
            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void WhenFirstBookOnly_Expect8()
        {
            var order = new Order() { First = 1 };
            var actual = priceCalulator.GetPrice(order);
            Assert.AreEqual(8, actual);
        }

        [TestMethod]
        public void WhenFirthBookOnly_Expect8()
        {
            var order = new Order() { Firth = 1 };
            var actual = priceCalulator.GetPrice(order);
            Assert.AreEqual(8, actual);
        }

        [TestMethod]
        public void When2FirstBookOnly_Expect16()
        {
            var order = new Order() { First = 2 };
            var actual = priceCalulator.GetPrice(order);
            Assert.AreEqual(16, actual);
        }

        [TestMethod]
        public void WhenFirstAndSeondBookOnly_Expect15and2()
        {
            var order = new Order() { First = 1, Second = 1 };
            var actual = priceCalulator.GetPrice(order);
            Assert.AreEqual(15.2m, actual);
        }

        [TestMethod]
        public void When2SetOf3And1Set2_Expect36and8()
        {
            var order = new Order() { First = 2, Second = 1, Third = 2 };
            var actual = priceCalulator.GetPrice(order);
            Assert.AreEqual(36.8m, actual);
        }

        [TestMethod]
        public void WhenOneSetAllBooks_Expect30()
        {
            var order = new Order() { First = 1, Second = 1, Third = 1, Fourth = 1, Firth = 1 };
            var actual = priceCalulator.GetPrice(order);
            Assert.AreEqual(30, actual);
        }

        [TestMethod]
        public void WhenTwoCompleteSetsAllBooks_Expect60()
        {
            var order = new Order() { First = 2, Second = 2, Third = 2, Fourth = 2, Firth = 2 };
            var actual = priceCalulator.GetPrice(order);
            Assert.AreEqual(60, actual);
        }
    }
}
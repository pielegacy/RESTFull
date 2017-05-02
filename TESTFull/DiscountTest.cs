using Microsoft.VisualStudio.TestTools.UnitTesting;
using RESTFull.Models;

namespace TESTFull
{
    [TestClass]
    public class DiscountTest
    {
        [TestMethod]
        public void TestDiscountContent()
        {
            Discount dsc = new Discount() { Description = "Discount Test", DiscountPercentage = 10m };
            Assert.AreEqual("Discount Test", dsc.Description);
            Assert.AreEqual(10m, dsc.DiscountPercentage);
        }

        [TestMethod]
        public void TestDiscountRequired()
        {
            Discount dsc = new Discount() {DiscountPercentage = 10m };
            if (dsc.Description == null)
                Assert.Fail();            
        }

        [TestMethod]
        [DataRow(40, 60, 16)]
        [DataRow(10, 50, 5)]
        [DataRow(10, 10, 9)]
        [DataRow(20, 40, 12)]
        public void TestDiscountPrice(int price, int discount, int expected)
        {
            Discount dsc = new Discount() { Description = "Discount Test", DiscountPercentage = discount };
            MenuItem testMenuItem = new MenuItem() { Name = "Test Menu Item", Price = price, Type = MenuItemType.Main, DiscountId = dsc.Id, Discount =dsc };

            Assert.AreEqual(expected, testMenuItem.RetailPrice);
        }
    }
}

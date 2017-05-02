using Microsoft.VisualStudio.TestTools.UnitTesting;
using RESTFull.Models;

namespace TESTFull
{
    [TestClass]
    public class MenuItemTests
    {
        [TestMethod]
        public void TestNewMenuItem()
        {
            MenuItem testMenuItem = new MenuItem() { Name = "Test Menu Item", Price = 10m, Type = MenuItemType.Main };
            Assert.AreEqual("Test Menu Item", testMenuItem.Name);
            Assert.AreEqual(10m, testMenuItem.Price);
            Assert.AreEqual(MenuItemType.Main, testMenuItem.Type);
        }

        [TestMethod]
        public void TestMenuItemRequired()
        {

            MenuItem testMenuItem = new MenuItem() { Price = 10m, Type = MenuItemType.Main };
            if (testMenuItem.Name == null)
                Assert.Fail();
        }
    }
}

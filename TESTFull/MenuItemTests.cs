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
            MenuItem testMenuItem = new MenuItem() { Name = "Test Menu Item", Price = 10m, Type = MenuItemType.Main, Calories= 1000};
            testMenuItem.Description = "some description";            

            Assert.AreEqual("Test Menu Item", testMenuItem.Name);
            Assert.AreEqual(10m, testMenuItem.Price);
            Assert.AreEqual(MenuItemType.Main, testMenuItem.Type);
            Assert.AreEqual(1000, testMenuItem.Calories);
            Assert.AreEqual("some description", testMenuItem.Description);

            //Required Attribute
            Assert.IsNotNull(testMenuItem.Name);
            Assert.IsNotNull(testMenuItem.Price);
            Assert.IsNotNull(testMenuItem.Type);
        }

        [TestMethod]
        public void TestMenuItemRequired()
        {
            // I can't test price and type somehow.
            MenuItem testMenuItem = new MenuItem() { Price = 10m, Type = MenuItemType.Main };
            if (testMenuItem.Name == null)
                Assert.Fail();
        }
    }
}

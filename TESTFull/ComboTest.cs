using Microsoft.VisualStudio.TestTools.UnitTesting;
using RESTFull.Models;

namespace TESTFull
{
    [TestClass]
    public class ComboTest
    {
        [TestMethod]
        public void TestComboContent()
        {
            Combo Com = new Combo() { ComboDescription = "Some description", ComboPrice = 9.8m };
            MenuItem Pizza = new MenuItem() { Name = "Pizza", Price = 8.8m, Type = MenuItemType.Main };
            Com.Items.Add(Pizza);

            Assert.AreSame(Pizza, Com.Items[0]);
            Assert.AreEqual("Some description", Com.ComboDescription);
            Assert.AreEqual(9.8m, Com.ComboPrice);
        }
    }
}
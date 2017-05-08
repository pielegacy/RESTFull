using Microsoft.VisualStudio.TestTools.UnitTesting;
using RESTFull.Models;

namespace TESTFull
{
    [TestClass]
    public class TagTest
    {
        [TestMethod]
        [DataRow("Chicken","Caesar Salad")]
        [DataRow("Veggie", "Caesar Salad")]
        [DataRow("Chicken", "Fried Chicken")]
        public void TestNewMenuItem(string a, string b)
        {
            Tag T = new Tag() { TagName = a};
            MenuItem food=new MenuItem(){Name=b, Price=8.8m, Type=MenuItemType.Main};
            T.Items.Add(food);

            Assert.AreSame(food,T.Items[0]);           
            Assert.AreEqual(a, T.TagName);
            Assert.AreEqual(b, T.MenuName);

            //Required Attribute
            Assert.IsNotNull(T.TagName);
        }

        [TestMethod]
        public void TestMenuItemRequired()
        {            
            Tag T = new Tag() { MenuName="SomeMenu"};

            Assert.IsNotNull(T.TagName);
        }
    }
}
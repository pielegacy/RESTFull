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
            Tag T = new Tag() { TagName = a, MenuName = b};            

            Assert.AreEqual(a, T.TagName);
            Assert.AreEqual(b, T.MenuName);

            //Required Attribute
            Assert.IsNotNull(T.TagName);
        }

        [TestMethod]
        public void TestMenuItemRequired()
        {            
            Tag T = new Tag() { MenuName="SomeMenu"};
            T.TagName = "SomeTag";
            Assert.IsNotNull(T.TagName);
        }
    }
}
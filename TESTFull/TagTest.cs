using System;
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
            food.Tags.add(T);

            Assert.AreSame(food,T.Items[0]);      
            Assert.AreEqual(a, T.TagName);            

            //Required Attribute
            Assert.IsNotNull(T.TagName);
        }    

        [TestMethod]
        public void TestTagRedundancy(string origin, string redundant)
        {
            Tag T1= new Tag() {TagName= origin};
            Tag T2 = new Tag() {TagName= redundant};

            Assert.AreEqual(T1.TagName.ToLower().Trim(),T2.TagName.ToLower().Trim());                                                      
        }
    }
}
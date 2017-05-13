using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RESTFull.Models;

namespace TESTFull
{
    [TestClass]
    public class TagTest
    {

        [TestMethod]
        [DataRowAttribute("Chicken","chicken")]
        [DataRowAttribute("Chicken","chicken ")]
        [DataRowAttribute("Chicken"," chicken ")]
        [DataRowAttribute("Chicken"," chicken")]
        public void TestTagRedundancy(string origin, string redundant)
        {
            Tag T1= new Tag() {TagName= origin};
            Tag T2 = new Tag() {TagName= redundant};

            Assert.AreEqual(T1.TagName.ToLower().Trim(),T2.TagName.ToLower().Trim());    
            Assert.IsTrue(T1 == T2);                                                  
        }
    }
}
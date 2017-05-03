using Microsoft.VisualStudio.TestTools.UnitTesting;
using RESTFull.Models;

namespace TESTFull
{
    [TestClass]
    public class StoreDetailsTest
    {
        [TestMethod]
        public void TestStoreDetailsRequired()
        {
            StoreDetails SD = new StoreDetails() { Proprietor = "Someone", AddressCity = "Somewhere" };
            if (SD.Name == null)
                Assert.Fail();           
        }

        [TestMethod]
        public void TestStoreDetailsContent()
        {
            StoreDetails SD = new StoreDetails() {Name="Branch-a", Proprietor = "Someone", AddressCity = "Melbourne", ABN="ABN" };
            SD.AddressCountry = "Australia";
            SD.AddressPostCode = "Z1234";
            SD.AddressState = "Victoria";
            SD.AddressStreet = "1234 Some Street";
            SD.AddressSuburb = "Suburb";
            SD.PhoneNumber = "123456789";

            Assert.AreEqual("Branch-a", SD.Name);
            Assert.AreEqual("Someone", SD.Proprietor);
            Assert.AreEqual("Melbourne", SD.AddressCity);
            Assert.AreEqual("ABN", SD.ABN);
            Assert.AreEqual("Australia", SD.AddressCountry);
            Assert.AreEqual("Z1234", SD.AddressPostCode);
            Assert.AreEqual("Victoria", SD.AddressState);
            Assert.AreEqual("1234 Some Street", SD.AddressStreet);
            Assert.AreEqual("Suburb", SD.AddressSuburb);
            Assert.AreEqual("123456789", SD.PhoneNumber);

            //Required Attribute
            Assert.IsNotNull(SD.Name);
        }
    }
}
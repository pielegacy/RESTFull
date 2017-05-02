using Microsoft.VisualStudio.TestTools.UnitTesting;
using RESTFull.Models;

namespace TESTFull
{
    [TestClass]
    public class BookingTest
    {
        [TestMethod]
        [DataRow(50,20,"Branch1")]
        public void TestBookingContent(int cap, int able, string name)
        {
            Booking Book = new Booking() { TableCapacity = cap, Available = able, StoreName= name};
            Assert.AreEqual(cap, Book.TableCapacity);
            Assert.AreEqual(able, Book.Available);
            Assert.AreEqual(name, Book.StoreName);
            if (Book.TableCapacity < Book.Available)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        [DataRow(null, 10, "")]
        [DataRow(78, null, "branch")]
        [DataRow(78, 22, null)]
        public void TestBookingRequired(int cap, int able, string name)
        {
            Booking Book = new Booking() { TableCapacity = cap, Available = able, StoreName = name };
            if (Book.TableCapacity == null)
                Assert.Fail();
            if (Book.Available == null)
                Assert.Fail();
            if (Book.StoreName == null)
                Assert.Fail();
        }
    }
}
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RESTFull.Models;

namespace TESTFull
{
   [TestClass]
    public class BookingTest
    {
        [TestMethod]
        [DataRow(1, 50, 20, "Branch1")]
        public void TestBookingContent(int number, int cap, int able, string name)
        {
            Booking Book = new Booking() { Number = number, TableCapacity = cap, Available = able, StoreName = name };

            Assert.AreEqual(number, Book.Number);
            Assert.AreEqual(cap, Book.TableCapacity);
            Assert.AreEqual(able, Book.Available);
            Assert.AreEqual(name, Book.StoreName);
            if (Book.TableCapacity < Book.Available)
            {
                Assert.Fail();
            }

            //Required Attribute
            Assert.IsNotNull(Book.TableCapacity);
            Assert.IsNotNull(Book.Available);
            Assert.IsNotNull(Book.StoreName);
        }

        [TestMethod]
        [DataRow(3, 2, 10, "branch")]
        [DataRow(1, 78, 3, "branch")]
        [DataRow(2, 78, 22, "branch")]
        public void TestBookingRequired(int number, int cap, int able, string name)
        {
            Booking Book = new Booking() { Number = number, TableCapacity = cap, Available = able, StoreName = name };
            if (Book.TableCapacity == null)
                Assert.Fail();
            if (Book.Available == null)
                Assert.Fail();
            if (Book.StoreName == null)
                Assert.Fail();
        }
    }
}
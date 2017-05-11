using System;
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
        }

        [TestMethod]
        [DataRow(3, 2, 10, "branch")]
        [DataRow(1, 78, 3, "branch")]
        [DataRow(2, 78, 22, "branch")]
        public void TestBookingRequired(int number, int cap, int able, string name)
        {
            Booking Book = new Booking() { Number = number, TableCapacity = cap, Available = able, StoreName = name };
           
            Assert.IsNotNull(Book.TableCapacity);
            Assert.IsNotNull(Book.Available);
            Assert.IsNotNull(Book.StoreName);
        }

        //after some consideration this is the best layout for booking
        [TestMethod]
        [DataRow("Alex", "1 May 2017 10:00")]
        [DataRow("Alex", "15 May 2017 19:00")]
        [DataRow("Alex", "21 May 2017 12:00")]
        public void TestBookingPerson(string name, string date)
        {
            Booking Book = new Booking() { Number&Capacity = {{10,2}, {11,2}, {12,2}}, People = 6, BookingName = name , Date=DateTime.Parse(date) };
            Assert.IsNotNull(Book.BookingName);
            Assert.IsNotNull(Book.Date);
            Assert.IsNotNull(Book.People);
            Assert.AreEqual(name, Book.BookingName);
            Assert.AreEqual(date,Book.Date);
        }
    }
}
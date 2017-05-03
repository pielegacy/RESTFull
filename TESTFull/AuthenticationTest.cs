using Microsoft.VisualStudio.TestTools.UnitTesting;
using RESTFull.Models;

namespace TESTFull
{
    [TestClass]
    public class AuthenticationTest
    {
        [TestMethod]
        public void TestAuthenticationContent()
        {
            Authentication At = new Authentication() { UserName = "Name1", Password = "Password" };

            Assert.AreEqual("Name1", At.UserName);
            Assert.AreEqual("Password", At.Password);

            //Required Attribute
            Assert.IsNotNull(At.UserName);
            Assert.IsNotNull(At.Password);
        }

        [TestMethod]
        [DataRow("Name", null)]
        [DataRow(null, "Password")]
        public void TestAuthenticationRequired(string a, string b)
        {
            Authentication At = new Authentication() { UserName = a; Password = b; };
            if (At.UserName == null)
                Assert.Fail();
            if (At.Password == null)
                Assert.Fail();
        }
    }
}
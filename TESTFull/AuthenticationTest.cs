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
        }

        [TestMethod]
        public void TestMenuItemRequired()
        {
            Authentication At = new Authentication();
            if (At.UserName == null)
                Assert.Fail();
            if (At.Password == null)
                Assert.Fail();
        }
    }
}
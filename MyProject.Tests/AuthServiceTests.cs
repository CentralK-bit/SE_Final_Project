using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyProject.BLL;

namespace MyProject.Tests
{
    [TestClass]
    public class AuthServiceTests
    {
        [TestMethod]
        public void Login_EmptyUsername_ReturnsFalse()
        {
            var auth = new AuthService();
            Assert.IsFalse(auth.Login("", "123"));
        }

        [TestMethod]
        public void Login_EmptyPassword_ReturnsFalse()
        {
            var auth = new AuthService();
            Assert.IsFalse(auth.Login("admin", ""));
        }

        [TestMethod]
        public void Login_ValidUser_ReturnsTrue()
        {
            var fakeRepo = new FakeUserRepository { ResultToReturn = true };
            var auth = new AuthService(fakeRepo);

            Assert.IsTrue(auth.Login("admin", "123"));
        }
    }
}
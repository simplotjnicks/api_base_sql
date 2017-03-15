using System.Collections.Generic;
using NSubstitute;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleApplication.Controllers;
using SampleApplication.Interfaces;
using SampleApplication.Models;

namespace SampleApplicationTests
{
    [TestClass]
    public class AuthenticationControllerTest
    {
        private IDatabaseShim _database;
        private AuthenticationController _controller;

        private Dictionary<string, User> _userPool;

        [TestInitialize]
        public void TestSetup()
        {
            _database = Substitute.For<IDatabaseShim>();
            _controller = new AuthenticationController(_database);

            var goodUser = new User() {UserName = "test", Password = "test"};
            var badUser = new User() {UserName = "test", Password = "badpassword"};
            _userPool = new Dictionary<string, User> {{"goodUser", goodUser}, {"badUser", badUser}};

            _database.Login(goodUser).Returns(true);
            _database.Login(badUser).Returns(false);
        }

        [TestMethod]
        public void LoginSuccess()
        {
            var user = _userPool["goodUser"];
            var response = _controller.Login(user);
            Assert.IsTrue(response.Contains(user.UserName));
        }

        [TestMethod]
        public void LoginFailure()
        {
            var user = _userPool["badUser"];
            var response = _controller.Login(user);
            Assert.IsTrue(response.Contains("Invalid"));
        }
    }
}

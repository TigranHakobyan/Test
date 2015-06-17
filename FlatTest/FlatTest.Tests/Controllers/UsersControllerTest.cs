using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FlatTest.Controllers;
using System.Web.Mvc;

namespace FlatTest.Tests.Controllers
{
    [TestClass]
    public class UsersControllerTest
    {
        [TestMethod]
        public void UserIndexViewResultNotNull()
        {
            UsersController controller = new UsersController();

            ViewResult result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void UserIndexViewModelNotNull()
        {
            UsersController controller = new UsersController();

            ViewResult result = controller.Index() as ViewResult;

            Assert.IsNotNull(result.Model);
        }
    }
}

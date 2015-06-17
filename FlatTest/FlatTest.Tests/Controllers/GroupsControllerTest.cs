using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FlatTest.Controllers;
using System.Web.Mvc;

namespace FlatTest.Tests.Controllers
{
    [TestClass]
    public class GroupsControllerTest
    {
        [TestMethod]
        public void GroupIndexViewResultNotNull()
        {
            GroupsController controller = new GroupsController();

            ViewResult result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GroupIndexViewModelNotNull()
        {
            GroupsController controller = new GroupsController();

            ViewResult result = controller.Index() as ViewResult;

            Assert.IsNotNull(result.Model);
        }
    }
}

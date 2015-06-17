using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FlatTest.Models;
using System.Collections.Generic;
using FlatTest.Controllers;
using System.Web.Mvc;

namespace FlatTest.Tests.Controllers
{
    [TestClass]
    public class StoriesControllerTest
    {
        [TestMethod]
        public void StoryIndexViewResultNotNull()
        {
            StoriesController controller = new StoriesController();

            ViewResult result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void StoryIndexViewModelNotNull()
        {
            StoriesController controller = new StoriesController();

            ViewResult result = controller.Index() as ViewResult;

            Assert.IsNotNull(result.Model);
        }
    }
}

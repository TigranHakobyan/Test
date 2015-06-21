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
        //[TestMethod]
        public void IndexViewResultNotNull()
        {
            StoriesController controller = new StoriesController();

            ViewResult result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
        }

      //  [TestMethod]
        public void IndexViewModelNotNull()
        {
            StoriesController controller = new StoriesController();

            ViewResult result = controller.Index() as ViewResult;

            Assert.IsNotNull(result.Model);
        }

        //[TestMethod]
        //public void StoriesDetailsView()
        //{
        //    //FlatTestContext db = new FlatTestContext();

        //    StoriesController controller = new StoriesController();

        //    ViewResult result = controller.Details(1) as ViewResult;

        //    Assert.AreEqual("Details", result.ViewName);

        //}


        //[TestMethod]
        //public void TestDetailsViewData()
        //{
        //    var controller = new StoriesController();
        //    var result = controller.Details(2) as ViewResult;
        //    var story = (Story)result.ViewData.Model;
        //    Assert.AreEqual("Story1", story.Title);
        //}
    }
}

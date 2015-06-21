using FlatTest.Models;
using FlatTest.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatTest.Tests
{
    ///
    ///https ://msdn.microsoft.com/en-us/data/dn314429
    ///https://azhidkov.wordpress.com/tag/moq/    --this one also good article
    ///

    [TestClass]
    public class MoqTest //NonQueryTests
    {
        //Testing non-query scenarios
        [TestMethod]
        public void CreateBlog_saves_a_blog_via_context()
        {
            var mockSet = new Mock<DbSet<Story>>();

            var mockContext = new Mock<ApplicationDbContext>();
            mockContext.Setup(m => m.Stories).Returns(mockSet.Object);

            var service = new StoryService(mockContext.Object);
            service.AddStory("Content test", "title test", "descr test", DateTime.Now, 1);

            mockSet.Verify(m => m.Add(It.IsAny<Story>()), Times.Once());
            //mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        //Testing query scenarios
        [TestMethod]
        public void GetAllStories_orders_by_name()
        {
            var data = new List<Story> 
            { 
                new Story { Content="Content test1", Title="title test1", Description="descr test1", PostedOn=DateTime.Now, UserID=1 }, 
                new Story { Content="Content test2", Title="title test2", Description="descr test2", PostedOn=DateTime.Now, UserID=2 }, 
                new Story { Content="Content test3", Title="title test3", Description="descr test3", PostedOn=DateTime.Now, UserID=3 }, 
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Story>>();
            mockSet.As<IQueryable<Story>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Story>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Story>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Story>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ApplicationDbContext>();
            mockContext.Setup(c => c.Stories).Returns(mockSet.Object);

            var service = new StoryService(mockContext.Object);
            var stories = service.GetAllStories();

            Assert.AreEqual(3, stories.Count);
            Assert.AreEqual("title test1", stories[0].Title);
            Assert.AreEqual("title test2", stories[1].Title);
            Assert.AreEqual("title test3", stories[2].Title);
        }
    } 

    //async part
    [TestClass]
    public class AsyncQueryTests
    {
        [TestMethod]
        public async Task GetAllBlogsAsync_orders_by_name()
        {

            var data = new List<Story> 
            { 
                new Story { Content="Content test1", Title="title test1", Description="descr test1", PostedOn=DateTime.Now, UserID=1 }, 
                new Story { Content="Content test2", Title="title test2", Description="descr test2", PostedOn=DateTime.Now, UserID=2 }, 
                new Story { Content="Content test3", Title="title test3", Description="descr test3", PostedOn=DateTime.Now, UserID=3 }, 
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Story>>();
            mockSet.As<IDbAsyncEnumerable<Story>>()
                .Setup(m => m.GetAsyncEnumerator())
                .Returns(new TestDbAsyncEnumerator<Story>(data.GetEnumerator()));

            mockSet.As<IQueryable<Story>>()
                .Setup(m => m.Provider)
                .Returns(new TestDbAsyncQueryProvider<Story>(data.Provider));

            mockSet.As<IQueryable<Story>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Story>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Story>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ApplicationDbContext>();
            mockContext.Setup(c => c.Stories).Returns(mockSet.Object);

            var service = new StoryService(mockContext.Object);
            var stories = await service.GetAllStoriesAsync();

            Assert.AreEqual(3, stories.Count);
            Assert.AreEqual("title test1", stories[0].Title);
            Assert.AreEqual("title test2", stories[1].Title);
            Assert.AreEqual("title test3", stories[2].Title);
        }
    } 
}

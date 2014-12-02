using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReadingList.Controllers;
using Moq;
using ReadingList.Models;
using System.Threading.Tasks;

namespace ReadingList.Tests.API_Test
{
    [TestClass]
    public class TestBookAPI
    {
        [TestMethod]
        public void TestIndex()
        {
            var fakeRepo = new Mock<IBookRepository>();  
            fakeRepo.Setup(x => x.GetAll()).Returns("Title:Test,Author:Matt,ID:1");
            var controller = new BooksController();
            controller.repository = fakeRepo.Object; 
            var result = controller.GetBooks().ToString(); 
            Assert.AreEqual("Title:Test,Author:Matt,ID:1", result);
        }
        [TestMethod]
        public void TestGetBook()
        {
            var fakeRepo = new Mock<IBookRepository>();
       /*    tricksy to test asyncs, working on it*/ 
        } 
    }
}

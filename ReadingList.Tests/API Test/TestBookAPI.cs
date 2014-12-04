using BookService.Models;
using Moq;
using NUnit.Framework;
using ReadingList.Controllers;
using ReadingList.Models;
using System.Threading.Tasks;
namespace ReadingList.Tests.API_Test
{   
    [TestFixture]
    public class TestBookAPI
    {
        [Test]
        public void TestIndex()
        {
            var fakeRepo = new Mock<IBookRepository>();  
            fakeRepo.Setup(x => x.GetAll()).Returns("Title:Test,Author:Matt,ID:1");
            var controller = new BooksController();
            controller.repository = fakeRepo.Object; 
            var result = controller.GetBooks().ToString(); 
            Assert.That(result, Is.EqualTo("Title:Test,Author:Matt,ID:1"));
        }

        [Test]
        public void ShouldAskRepoForSpecificBook()
        {
            var fakeRepo = new Mock<IBookRepository>();
            fakeRepo.Setup(x => x.Get(1)).ReturnsAsync(It.IsAny<BookDetailDTO>());
            var controller = new BooksController();
            controller.repository = fakeRepo.Object;
            var result = controller.GetBook(1);
            fakeRepo.Verify(fk => fk.Get(1));
            Assert.That(true);
        } 

        [Test]
        public void ShouldCallPostNewBookCorrectly()
        {
            var fakeRepo = new Mock<IBookRepository>();
            fakeRepo.Setup(x => x.Post(It.IsAny<Book>())); 
        }
        public void ShouldCallDelete()
        {

        }
    }
}

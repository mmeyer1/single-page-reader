using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using BookService.Models;
using ReadingList.Models;
using ReadingList.Controllers;


namespace ReadingList.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private ReadingListContext db = new ReadingListContext();

        [TestMethod]
        public void GetAllBooks_ShouldReturnAllBooks()
        {
            var testBooks = GetBooks();
            var controller = new BooksController();

            var result = controller.GetBooks() as IQueryable<BookDTO>;
            Assert.AreEqual(testBooks, result);

        }

        private IQueryable<Book> GetBooks(){
            var books = from b in db.Books
                        select new BookDTO()
                        {
                            Id = b.Id,
                            Title = b.Title,
                            AuthorName = b.Author.Name
                        };

            return null;
     }
    }
}

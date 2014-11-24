using BookService.Models;
using System;
using System.Collections.Generic;


namespace ReadingList.Models
{
    public interface IBookRepository
    {
        void CreateNewBook(Book booktoCreate);
        void DeleteBook(int id);
        Book GetBookById(int id);
        IEnumerable<Book> GetAllBooks();
        int SaveChanges(); 

    }
}
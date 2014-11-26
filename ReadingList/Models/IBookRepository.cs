using BookService.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ReadingList.Models
{
    public interface IBookRepository
    {
        IEnumerable GetAll();
        Task<BookDetailDTO> Get(int id);
        Task<Boolean> Put(int id, Book book);
        Task<Book> Post(Book book);
        Task<Boolean> Delete(int id);
    }
}
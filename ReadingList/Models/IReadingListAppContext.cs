using BookService.Models;
using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace ReadingList.Models
{
    public interface IReadingListAppContext : IDisposable
    {
        DbSet<Book> Books { get; }
        int SaveChanges();
        Task<Int32> SaveChangesAsync();
        void MarkAsModified(Book item);
        void LoadAuthors(Book item);
    }
}

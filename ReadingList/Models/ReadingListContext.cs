﻿using BookService.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ReadingList.Models
{
    public class ReadingListContext : DbContext, IReadingListAppContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public ReadingListContext() : base("name=ReadingListContext")
        {
        }

        public System.Data.Entity.DbSet<BookService.Models.Author> Authors { get; set; }

        public System.Data.Entity.DbSet<BookService.Models.Book> Books { get; set; }

        public void MarkAsModified(Book item)
        {
            Entry(item).State = EntityState.Modified;
        }

        public void LoadAuthors(Book item)
        {
            Entry(item).Reference(x => x.Author).Load();
        }
    }
}

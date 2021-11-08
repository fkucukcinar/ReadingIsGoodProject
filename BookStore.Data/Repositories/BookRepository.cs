using BookStore.Core.Models;
using BookStore.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Data.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(BookStoreDbContext context)
            : base(context)
        { }
        private BookStoreDbContext BookStoreDbContext
        {
            get { return Context as BookStoreDbContext; }
        }
    }
}

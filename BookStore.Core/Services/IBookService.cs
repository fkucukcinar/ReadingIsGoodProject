using BookStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core.Services
{
    public interface IBookService
    {
        Task<Book> UpdateBookStock(int bookId, int stockChangeAmount);
    }
}

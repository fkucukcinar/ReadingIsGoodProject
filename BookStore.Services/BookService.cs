using BookStore.Core;
using BookStore.Core.Models;
using BookStore.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;
        public BookService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<Book> UpdateBookStock(int bookId, int stockChangeAmount)
        {
            var book = await _unitOfWork.Books.GetByIdAsync(bookId);
            book.Stock = book.Stock + stockChangeAmount;
            await _unitOfWork.CommitAsync();
            return book;
        }
    }
}

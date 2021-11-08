using BookStore.Core;
using BookStore.Core.Repositories;
using BookStore.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BookStoreDbContext _context;
        private CustomerRepository _customerRepository;
        private OrderRepository _orderRepository;
        private OrderDetailRepository _orderDetailRepository;
        private BookRepository _bookRepository;

        public UnitOfWork(BookStoreDbContext context)
        {
            this._context = context;
        }

        public ICustomerRepository Customers => _customerRepository = _customerRepository ?? new CustomerRepository(_context);

        public IBookRepository Books => _bookRepository = _bookRepository ?? new BookRepository(_context);
        public IOrderRepository Orders => _orderRepository = _orderRepository ?? new OrderRepository(_context);
        public IOrderDetailRepository OrderDetails => _orderDetailRepository = _orderDetailRepository ?? new OrderDetailRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

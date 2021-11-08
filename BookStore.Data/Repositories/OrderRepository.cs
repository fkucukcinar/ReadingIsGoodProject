using BookStore.Core.Models;
using BookStore.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Data.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(BookStoreDbContext context)
            : base(context)
        { }
        
        private BookStoreDbContext BookStoreDbContext
        {
            get { return Context as BookStoreDbContext; }
        }

        public async Task<Order> GetCustomerOrders(int customerId)
        {
            return await BookStoreDbContext
                .Orders.Include(p => p.OrderDetails).Where(p => p.CustomerId == customerId).FirstOrDefaultAsync();
        }

        public async Task<Order> GetOrders(int customerId)
        {
            return await BookStoreDbContext
                .Orders.Where(p => p.CustomerId == customerId).FirstOrDefaultAsync();
        }

       
    }
}

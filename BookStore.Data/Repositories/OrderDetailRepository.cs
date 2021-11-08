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
    public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(BookStoreDbContext context)
           : base(context)
        { }
        private BookStoreDbContext BookStoreDbContext
        {
            get { return Context as BookStoreDbContext; }
        }

        public async Task<List<OrderDetail>> GetOrderDetails(int orderId)
        {
            return await BookStoreDbContext.OrderDetails.Where(b => b.OrderId == orderId).ToListAsync();
        }
    }
}

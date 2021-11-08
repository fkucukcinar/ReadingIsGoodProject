using BookStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<Order> GetCustomerOrders(int customerId);
       // Task UpdateOrder(Order orderToBeUpdated, Order order);
        Task<Order> GetOrders(int customerId);

    }
}

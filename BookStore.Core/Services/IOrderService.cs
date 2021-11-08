using BookStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core.Services
{
    public interface IOrderService
    {
        Task<Order> CreateOrder(Order newOrder);
        Task UpdateOrder(Order orderToBeUpdated, Order Order);
        Task<Order> GetOrders(int customerId);
        Task<Order> GetOrderById(int id);
    }
}

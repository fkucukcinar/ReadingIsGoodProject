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
    public class OrderService: IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Order> CreateOrder(Order newOrder)
        {
            await _unitOfWork.Orders.AddAsync(newOrder);
            await _unitOfWork.CommitAsync();
            return newOrder;
        }

        public async Task<Order> GetOrders(int customerId)
        {
            return await _unitOfWork.Orders.GetCustomerOrders(customerId);
        }

        public async Task UpdateOrder(Order orderToBeUpdated, Order order)
        {
            orderToBeUpdated.StatusId = order.StatusId;

            await _unitOfWork.CommitAsync();
        }
        public async Task<Order> GetOrderById(int id)
        {
            return await _unitOfWork.Orders.GetByIdAsync(id);

        }
    }
}

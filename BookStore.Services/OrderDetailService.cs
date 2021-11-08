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
    public class OrderDetailService: IOrderDetailService
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderDetailService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<OrderDetail> CreateOrderDetail(OrderDetail orderDetail)
        {
            await _unitOfWork.OrderDetails.AddAsync(orderDetail);
            await _unitOfWork.CommitAsync();
            return orderDetail;
        }
        public async Task<List<OrderDetail>> GetOrderDetails(int orderId)
        {
            return await _unitOfWork.OrderDetails.GetOrderDetails(orderId);
        }
    }
}

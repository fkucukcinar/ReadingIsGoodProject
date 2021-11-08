using BookStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core.Repositories
{
    public interface IOrderDetailRepository: IRepository<OrderDetail>
    {
        Task<List<OrderDetail>> GetOrderDetails(int orderId);
    }
}

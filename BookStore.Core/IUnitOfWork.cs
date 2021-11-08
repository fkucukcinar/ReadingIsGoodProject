using BookStore.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core
{
    public interface IUnitOfWork: IDisposable
    {
        ICustomerRepository Customers { get; }
        IOrderRepository Orders { get; }
        IOrderDetailRepository OrderDetails { get; }
        IBookRepository Books { get; }
        Task<int> CommitAsync();
    }
}

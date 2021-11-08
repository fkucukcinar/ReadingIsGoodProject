using BookStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core.Services
{
    public interface ICustomerService
    {
        Task<Customer> CreateCustomer(Customer newCustomer);
        Task<Customer> GetCustomerById(int id);
    }
}

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
    public class CustomerService: ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CustomerService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Customer> CreateCustomer(Customer newCustomer)
        {
            await _unitOfWork.Customers.AddAsync(newCustomer);
            await _unitOfWork.CommitAsync();
            return newCustomer;
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            return await _unitOfWork.Customers.GetByIdAsync(id);
            
        }
    }
}

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
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(BookStoreDbContext context)
            : base(context)
        { }
        public async Task<IEnumerable<Customer>> GetAllCustomerAsync()
        {
            return await BookStoreDbContext.Customers.ToListAsync();
        }


        private BookStoreDbContext BookStoreDbContext
        {
            get { return Context as BookStoreDbContext; }
        }

       
    }
}

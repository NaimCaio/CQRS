using CQRS.Domain.Entities;
using CQRS.Domain.Interfaces.Infrastructure;
using CQRS.Infrastructure.context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _appDbContext;

        public CustomerRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var customer = await _appDbContext.Customers.FindAsync(id);
            if (customer == null)
            {
                return false;
            }
            _appDbContext.Customers.Remove(customer);
            await _appDbContext.SaveChangesAsync();
            return true;

        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _appDbContext.Customers.ToListAsync();
        }

        public async Task<Customer> GetAsync(string id)
        {
            return await _appDbContext.Customers.FindAsync(id);
        }

        public async Task<int> GetCountAsync()
        {
            return await _appDbContext.Customers.CountAsync();
        }

        public async Task<bool> InsertAsync(Customer entity)
        {
            await _appDbContext.AddAsync(entity);
            await _appDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(Customer entity)
        {
            _appDbContext.Update(entity);
            await _appDbContext.SaveChangesAsync();
            return true;
        }
    }
}

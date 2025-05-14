using CQRS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Domain.Interfaces.Infrastructure
{
    public interface ICustomerRepository: IGenericRepository<Customer>
    {
        Task<int> GetCountAsync();
    }
}

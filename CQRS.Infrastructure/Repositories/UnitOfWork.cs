using CQRS.Domain.Interfaces.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICustomerRepository Customers { get; set; }
        public UnitOfWork(ICustomerRepository customers) 
        {
            Customers = customers;
        }
    }
}

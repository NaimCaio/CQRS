using AutoMapper;
using CQRS.Application.Commons.Bases;
using CQRS.Application.DTOs;
using CQRS.Domain.Entities;
using CQRS.Domain.Interfaces.Infrastructure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Queries.Customers.GetAllCustomers
{
    public class GetAllCustomersHandler : IRequestHandler<GetAllCustomersQuery, BaseResponse<IEnumerable<CustomerDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        public GetAllCustomersHandler(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }
        public async Task<BaseResponse<IEnumerable<CustomerDto>>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<IEnumerable<CustomerDto>>();
            try
            {
                IEnumerable<Customer> customers= await _uow.Customers.GetAllAsync();
                if (customers != null) 
                {
                    response.Data = _mapper.Map<IEnumerable<CustomerDto>>(customers);
                    response.succcess = true;
                    response.Message = "list returned";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
    }
}

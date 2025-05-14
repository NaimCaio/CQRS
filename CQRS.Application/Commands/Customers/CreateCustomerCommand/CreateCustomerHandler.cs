using AutoMapper;
using CQRS.Application.Commons.Bases;
using CQRS.Domain.Entities;
using CQRS.Domain.Interfaces.Infrastructure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Commands.Customers.CreateCustomerCommand
{
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, BaseResponse<bool>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        public CreateCustomerHandler(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _uow = uow;
        }
        public async Task<BaseResponse<bool>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();
            try
            {
                var customer = _mapper.Map<Customer>(request);
                response.Data = await _uow.Customers.InsertAsync(customer);
                if (response.Data)
                {
                    response.succcess = true;
                    response.Message = "Success";
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

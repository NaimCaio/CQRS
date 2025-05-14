using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Commands.Customers.CreateCustomerCommand
{
    public class CreateCustomerValidator: AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerValidator()
        {
            RuleFor(x => x.CustomerId).NotEmpty().NotNull().MinimumLength(5).MaximumLength(5);
            RuleFor(x => x.ContactName).NotEmpty().NotNull();
        }
    }
}

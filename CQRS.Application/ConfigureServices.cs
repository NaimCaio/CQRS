using AutoMapper;
using CQRS.Application.Commands.Customers.CreateCustomerCommand;
using CQRS.Application.DTOs;
using CQRS.Domain.Entities;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CQRS.Application
{
    public static class ConfigureServices
    {
        public static void AddInjectionApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CreateCustomerCommand, Customer>();
                cfg.CreateMap<Customer, CustomerDto>();
            });

            // Registrando o AutoMapper manualmente
            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}

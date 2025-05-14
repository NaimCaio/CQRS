using CQRS.Domain.Interfaces.Infrastructure;
using CQRS.Infrastructure.context;
using CQRS.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CQRS.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInjectionInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseInMemoryDatabase("MyInMemoryDb"));
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}

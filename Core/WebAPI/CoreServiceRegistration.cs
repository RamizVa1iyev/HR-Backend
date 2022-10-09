using Core.DataAccess.Concrete.EntityFramework.Contexts;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Core.WebAPI
{   // Demo. working on it
    public static class CoreServiceRegistration
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CoreContext>(options => options.UseSqlServer(configuration.GetConnectionString("SqlServer")));
            return services;
        }
    }
}

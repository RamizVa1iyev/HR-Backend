using Core.Business.Abstract;
using Core.Business.Concrete;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Caching.Microsoft;
using Core.DataAccess.Abstract;
using Core.DataAccess.Concrete.EntityFramework;
using Core.Features.IoC;
using Core.Features.Security.Jwt;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;

namespace Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddMemoryCache();
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            serviceCollection.AddSingleton<ICacheManager, MemoryCacheManager>();
            serviceCollection.AddSingleton<Stopwatch>();
            serviceCollection.AddSingleton<ITokenHelper, JwtHelper>();
            serviceCollection.AddScoped<IAuthService, AuthManager>();
            serviceCollection.AddScoped<IUserService, UserManager>();
            serviceCollection.AddScoped<IUserRepository, EfUserRepository>();
            serviceCollection.AddScoped<IUserOperationClaimService, UserOperationClaimManager>();
            serviceCollection.AddScoped<IUserOperationClaimRepository, EfUserOperationClaimRepository>();
            serviceCollection.AddScoped<IOperationClaimRepository, EfOperationClaimRepository>();
            serviceCollection.AddScoped<IOperationClaimService, OperationClaimManager>();
        }
    }
}

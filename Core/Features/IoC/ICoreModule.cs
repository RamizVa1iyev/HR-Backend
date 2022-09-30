using Microsoft.Extensions.DependencyInjection;

namespace Core.Features.IoC
{
    public interface ICoreModule
    {
        void Load(IServiceCollection serviceCollection);
    }
}

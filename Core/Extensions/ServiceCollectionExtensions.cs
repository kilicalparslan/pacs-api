
using pdksApi.Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace pdksApi.Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencyResolver(this IServiceCollection services,
            ICoreModule[] coreModules)
        {
            foreach (var module in coreModules)
            {
                module.Load(services);
            }
            return ServiceTool.Create(services);
        }
    }
}

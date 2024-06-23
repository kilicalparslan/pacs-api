using Microsoft.Extensions.DependencyInjection;

namespace pdksApi.Core.Utilities.IoC
{
    public interface ICoreModule
    {
        void Load(IServiceCollection collection);
    }
}

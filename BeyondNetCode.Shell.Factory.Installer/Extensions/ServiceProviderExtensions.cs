using BeyondNetCode.Shell.Factory.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BeyondNetCode.Shell.Factory.Installer.Extensions
{
    public static class ServiceProviderExtensions
    {
        public static IFactory GetFactory(this IServiceProvider provider)
        {
            return provider.GetService<IFactory>();
        }
    }
}

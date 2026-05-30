using BeyondNetCode.Shell.Factory.Model;

namespace BeyondNetCode.Shell.Factory.Interfaces
{
    public interface IFactorySetupProvider
    {
        IEnumerable<IFactorySetupSource> Sources { get; }

        Setup Configuration { get; }

        SetupItem[] Provide<TTarget, TService>(TTarget target, string name);
    }
}

using BeyondNetCode.Shell.Factory.Fluent.Interfaces;
using BeyondNetCode.Shell.Factory.Model;

namespace BeyondNetCode.Shell.Factory
{
    public class FactorySetupWhenBuilder<TTarget> : IFactoryRecordSetupWhenBuilder<TTarget>
    {
        private readonly SetupItem _item;

        public FactorySetupWhenBuilder(SetupItem item)
        {
            _item = item;
        }

        public void When(Func<TTarget, bool> selector)
        {
            _item.Selector = selector;
        }
    }
}

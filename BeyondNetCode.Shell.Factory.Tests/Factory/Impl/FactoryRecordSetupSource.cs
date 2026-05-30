using BeyondNetCode.Shell.Factory.Impl;
using BeyondNetCode.Shell.Factory.Test.Interfaces;
using BeyondNetCode.Shell.Factory.Test.Models;

namespace BeyondNetCode.Shell.Factory.Test.Impl
{
    public class FactoryRecordSetupSource : AbstractFactorySetupSource
    {
        public FactoryRecordSetupSource()
        {
            For<Consultant, IDoSomething>().Create<DoSomething>().When(x => x.Age > 18);
            For<Consultant, IDoSomething>().Create<DoSomethingLessThan18>().When(x => x.Age < 18);
        }
    }

}


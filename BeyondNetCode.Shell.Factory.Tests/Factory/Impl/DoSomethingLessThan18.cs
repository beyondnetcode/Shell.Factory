using BeyondNetCode.Shell.Factory.Test.Interfaces;

namespace BeyondNetCode.Shell.Factory.Test.Impl
{
    public class DoSomethingLessThan18 : IDoSomething
    {
        public bool Apply()
        {
            return true;
        }
    }
}
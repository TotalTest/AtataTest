using Atata;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AtataPoc
{
    [TestClass]
    public class UnitTest1 : RunContext
    {
        [TestMethod]
        public void HappyTest()
        {
            Go.To<TestPage>();

        }
    }
}

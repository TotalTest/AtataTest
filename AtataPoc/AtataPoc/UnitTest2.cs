using Atata;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AtataPoc
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod, Ignore]
        public void ATest()
        {
            System.Console.WriteLine("Running test 1");
            Assert.AreEqual(1, 2);
        }

        [TestMethod, Ignore]
        [TestCategory("mas")]
        public void BTest()
        {
            System.Console.WriteLine("Running test 2");
            Assert.AreEqual(3, 4);
        }
    }
}

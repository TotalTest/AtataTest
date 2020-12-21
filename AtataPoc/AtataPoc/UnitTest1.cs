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
            var title = Go.To<TestPage>().PageTitle;

            Assert.AreEqual("as", title);
        }

        [TestMethod]
        public void AnotherTest()
        {
            Go.To<AnotherPage>();
        }
    }
}

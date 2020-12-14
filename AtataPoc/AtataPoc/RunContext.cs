using Atata;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AtataPoc
{
    [TestClass]
    public class RunContext
    {
        public TestContext TestContext { get; set; }

        private string _folderName;

        [TestInitialize]
        public void Start()
        {
            var browser = TestContext.Properties["browser"]?.ToString() ?? "chrome";
            AtataContext.Configure()
                .UseTestName(TestContext.TestName)
                .UseDriver(DriverAlias(browser))
                .AddScreenshotFileSaving().WithFolderPath(() => $@"{TestContext.TestResultsDirectory}\{AtataContext.Current.TestName}")//.WithFileName(a => $"Image_{a.Number}")
                .Build();

            _folderName = $@"{TestContext.TestResultsDirectory}\{AtataContext.Current.TestName}";
        }

        private string DriverAlias(string browser)
        {
            switch (browser.ToLowerInvariant())
            {
                case "chrome":
                    return DriverAliases.Chrome;
                case "firefox":
                    return DriverAliases.Firefox;
                case "ie":
                    return DriverAliases.InternetExplorer;
                default:
                    return DriverAliases.Chrome;
            }
        }

        [TestCleanup]
        public void End()
        {
            //if (AtataContext.Current.AssertionResults.Count > 0)
            //{
                AtataContext.Current.Log.Screenshot("Failure");
                TestContext.AddResultFile($"{_folderName}\\01 - Test page - Failure.png");
            //}

            AtataContext.Current?.CleanUp();
        }
    }
}

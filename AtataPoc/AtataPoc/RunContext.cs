using Atata;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.IO;

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
                //AtataContext.Current.Log.Screenshot("Failure");
                //TestContext.AddResultFile($"{_folderName}\\01 - Test page - Failure.png");
            //}

            

            var path = Path.Combine(_folderName);
            var p = Directory.GetParent(path);
            var t = Directory.GetParent(p.FullName);

            using (StreamWriter sw = File.CreateText($"{t}\\test.txt"))
            {
                sw.WriteLine("Hello");
                sw.WriteLine("And");
                sw.WriteLine("Welcome");
            }

            TestContext.AddResultFile($"{t}\\test.txt");


            var apath = Path.Combine(_folderName);
            var ap = Directory.GetParent(path);
            var at = Directory.GetParent(p.FullName);

            using (StreamWriter sw = File.CreateText($"{at}\\test.txt"))
            {
                sw.WriteLine("Hello");
                sw.WriteLine("And");
                sw.WriteLine("Welcome");
            }

            TestContext.AddResultFile($"{at}\\test.txt");




            AtataContext.Current?.CleanUp();

            var dir = Environment.GetEnvironmentVariable("Agent.TempDirectory");

            throw new Exception($"cus: {dir} and + and {_folderName} and + and {t} and + and {at}");
        }
    }
}

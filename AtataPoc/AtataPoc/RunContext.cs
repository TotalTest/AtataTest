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

        //private static readonly string BaseFile = $@"Logs\{DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss")}";
        private string _folderName;

        [TestInitialize]
        public void Start()
        {
            _folderName = @$"{TestContext.ResultsDirectory}\{TestContext.TestName}";

            var browser = TestContext.Properties["browser"]?.ToString() ?? "chrome";
            var test = AtataContext.Configure()
                .UseTestName(TestContext.TestName)
                //.UseDriver(DriverAlias(browser))
                .AddScreenshotFileSaving().WithFolderPath(_folderName)
                .WithFileName(screenshotInfo => $"{screenshotInfo.Number:D2} - {screenshotInfo.PageObjectFullName}{screenshotInfo.Title?.Prepend(" - ")}")
                .AddLogConsumer(new TextOutputLogConsumer(TestContext.WriteLine))
                //.AddScreenshotFileSaving().WithFolderPath(() => $@"{TestContext.TestResultsDirectory}\{AtataContext.Current.TestName}")//.WithFileName(a => $"Image_{a.Number}")
                .Build();


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
                    throw new Exception("no browser");
            }
        }

        [TestCleanup]
        public void End()
        {
            //if (TestContext.CurrentTestOutcome == UnitTestOutcome.Error || TestContext.CurrentTestOutcome == UnitTestOutcome.Failed)
            //{
            //    AtataContext.Current?.Log.Screenshot("Failure");
            //TestContext.AddResultFile($"{_folderName}\\01 - Test page - Failure.png");
            //}

            
            AtataContext.Current?.Log.Screenshot("Two");

            if (Directory.Exists(_folderName))
            {
                foreach (var f in Directory.GetFiles(_folderName))
                    TestContext.AddResultFile(f);
            }
            

            //var apath = Path.Combine(_folderName);
            //var ap = Directory.GetParent(apath);
            //var at = Directory.GetParent(ap.FullName);
            //var att = Directory.GetParent(at.FullName);
            //
            //using (StreamWriter sw = File.CreateText($"{att}\\test2.txt"))
            //{
            //    sw.WriteLine("Hello");
            //    sw.WriteLine("And");
            //    sw.WriteLine("Welcome");
            //}
            //
            //TestContext.AddResultFile($"{att}\\test2.txt");

            AtataContext.Current?.CleanUp();

            //var test = Directory.GetFiles(att.FullName);
            //string tests = "";
            //foreach (var t in test)
            //{
            //    tests += t;
            //}
            //throw new Exception($"files count: {test.Length}...names: {tests}");
        }
    }
}

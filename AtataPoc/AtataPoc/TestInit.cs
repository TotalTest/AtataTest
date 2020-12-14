using Atata;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace AtataPoc
{
    [TestClass]
    public static class TestInit
    {
        [AssemblyInitialize]
        public static void Init(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext context)
        {
            AtataContext.GlobalConfiguration
                //UseChrome()
                .UseChrome().WithDriverPath(Environment.GetEnvironmentVariable("ChromeWebDriver"))
                .UseFirefox().WithDriverPath(Environment.GetEnvironmentVariable("GeckoWebDriver"))
                .UseInternetExplorer().WithDriverPath(Environment.GetEnvironmentVariable("IEWebDriver"))
                .UseBaseUrl("https://google.co.uk");
        }
    }
}

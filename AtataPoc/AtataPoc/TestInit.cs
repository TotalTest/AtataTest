using Atata;
using Atata.WebDriverSetup;
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
            var browser = context.Properties["browser"]?.ToString();
            var baseurl = context.Properties["baseurl"]?.ToString();
            var custom = context.Properties["custom"]?.ToString();

            //throw new Exception($"params: {browser} : {baseurl} : {custom}");

            DriverSetup.AutoSetUp(BrowserNames.Chrome);

            

            AtataContext.GlobalConfiguration
                .UseBaseUrl("https://google.co.uk")
                .UseDriver(DriverAliases.Chrome)
                .AutoSetUpConfiguredDrivers();
                //.UseChrome()
                //.AutoSetUpDriverToUse();
                //.UseChrome().WithDriverPath(Environment.GetEnvironmentVariable("ChromeWebDriver"))
                //.UseFirefox().WithDriverPath(Environment.GetEnvironmentVariable("GeckoWebDriver"))
                //.UseInternetExplorer().WithDriverPath(Environment.GetEnvironmentVariable("IEWebDriver"))
                
        }
    }
}

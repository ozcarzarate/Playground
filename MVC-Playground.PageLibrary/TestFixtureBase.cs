using MVC_Playground.PageLibrary.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using System.Drawing.Imaging;
using TechTalk.SpecFlow;

namespace MVC_Playground.PageLibrary
{
    public class TestFixtureBase
    {
        protected PageBase NextPage
        {
            set
            {
                CurrentPage = value;
            }
        }

        protected PageBase CurrentPage
        {
            get
            {
                return (PageBase)ScenarioContext.Current["CurrentPage"];
            }
            set
            {
                ScenarioContext.Current["CurrentPage"] = value;
            }
        }

        protected RemoteWebDriver CurrentDriver { get; set; }

        [SetUp]
        public void Test_Setup()
        {
            var fb = String.IsNullOrWhiteSpace(MvcPlaygroundSettings.CurrentSettings.FirefoxBinaryPath)
                ? new FirefoxBinary()
                : new FirefoxBinary(MvcPlaygroundSettings.CurrentSettings.FirefoxBinaryPath);
            CurrentDriver = new FirefoxDriver(fb, new FirefoxProfile());
        }


        [TearDown]
        public void Test_Teardown()
        {
            try
            {
                var driver = CurrentDriver as ITakesScreenshot;
                if (TestContext.CurrentContext.Result.Status == TestStatus.Failed && driver != null)
                {
                    driver.GetScreenshot().SaveAsFile(TestContext.CurrentContext.Test.FullName + ".jpg", ImageFormat.Jpeg);
                }
            }
            catch { }	// null ref exception occurs from accessing TestContext.CurrentContext.Result.Status property

            try
            {
                if (CurrentDriver != null)
                {
                    CurrentDriver.Quit();
                }
            }
            catch { }
        }


        [BeforeScenario("UI")]
        public void BeforeScenario()
        {
            if (ScenarioContext.Current.ContainsKey("CurrentDriver"))
            {
                CurrentDriver = (RemoteWebDriver)ScenarioContext.Current["CurrentDriver"];
            }
            else
            {
                Test_Setup();
                ScenarioContext.Current.Add("CurrentDriver", CurrentDriver);
            }
        }

        [AfterScenario("UI")]
        public void AfterScenario()
        {
            if (ScenarioContext.Current.ContainsKey("CurrentDriver"))
            {
                Test_Teardown();
                ScenarioContext.Current.Remove("CurrentDriver");
            }
        }
    }
}
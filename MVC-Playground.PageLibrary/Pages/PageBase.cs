using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace MVC_Playground.PageLibrary.Pages
{
    public abstract class PageBase : IDisposable
    {
        public RemoteWebDriver Driver { get; set; }

        public string BaseUrl { get; set; }

        public virtual string DefaultTitle
        {
            get
            {
                return String.Empty;
            }
        }

        protected TPage GetInstance<TPage>(RemoteWebDriver driver = null, string expectedTitle = "") where TPage : PageBase, new()
        {
            return GetInstance<TPage>(driver ?? Driver, BaseUrl, expectedTitle);
        }

        protected static TPage GetInstance<TPage>(RemoteWebDriver driver, string baseUrl, string expectedTitle) where TPage : PageBase, new()
        {
            var pageInstance = new TPage
            {
                Driver = driver,
                BaseUrl = baseUrl
            };
            PageFactory.InitElements(driver, pageInstance);

            if (string.IsNullOrWhiteSpace(expectedTitle))
            {
                expectedTitle = pageInstance.DefaultTitle;
            }

            //wait up to 5s for an actual page title since Selenium no longer waits for page to load after 2.21
            new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(d => d.FindElement(By.TagName("body")));

            AssertIsEqual(expectedTitle, driver.Title, "Page Title");

            return pageInstance;
        }

        /// <summary>
        /// Asserts that the current page is of the given type
        /// </summary>
        public void Is<TPage>() where TPage : PageBase, new()
        {
            if (!(this is TPage))
            {
                throw new AssertionException(String.Format("Page Type Mismatch: Current page is not a '{0}'", typeof(TPage).Name));
            }
        }

        /// <summary>
        /// Inline cast to the given page type
        /// </summary>
        public TPage As<TPage>() where TPage : PageBase, new()
        {
            return (TPage)this;
        }

        public static void AssertIsEqual(string expectedValue, string actualValue, string elementDescription)
        {
            if (expectedValue != actualValue)
            {
                throw new AssertionException(String.Format("AssertIsEqual Failed: '{0}' didn't match expectations. Expected [{1}], Actual [{2}]", elementDescription, expectedValue, actualValue));
            }
        }

        public void Dispose()
        {
            Driver.Dispose();
        }
    }
}

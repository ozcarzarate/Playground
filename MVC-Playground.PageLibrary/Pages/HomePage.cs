using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.PageObjects;

namespace MVC_Playground.PageLibrary.Pages
{
    public class HomePage : PageBase
    {
        private const string Url = "/";
        public override string DefaultTitle
        {
            get
            {
                return "Home Page - My ASP.NET Application";
            }
        }

        [FindsBy(How = How.LinkText, Using = "Movies")]
        private IWebElement LinkToMovies { get; set; }

        public MoviesPage NavigateToMovies()
        {
            LinkToMovies.Click();
            return GetInstance<MoviesPage>();
        }

        public static HomePage LoadHomePage(RemoteWebDriver driver, string baseUrl)
        {
            driver.Navigate().GoToUrl(baseUrl.TrimEnd(new char[] { '/' }) + Url);
            return GetInstance<HomePage>(driver, baseUrl, "");
        }
    }
}
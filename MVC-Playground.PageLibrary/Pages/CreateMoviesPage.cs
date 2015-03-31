using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace MVC_Playground.PageLibrary.Pages
{
    public class CreateMoviesPage : PageBase
    {
        public override string DefaultTitle
        {
            get
            {
                return "Create New Movie - My ASP.NET Application";
            }
        }

        [FindsBy(How = How.Name, Using = "Name")]
        public IWebElement NameTextBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@class='btn btn-default']")]
        private IWebElement CreateButton { get; set; }

        public MoviesPage ClickOnCreate()
        {
            CreateButton.Click();
            return GetInstance<MoviesPage>();
        }
    }
}
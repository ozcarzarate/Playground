using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace MVC_Playground.PageLibrary.Pages
{
    public class MoviesPage : PageBase
    {
        public override string DefaultTitle
        {
            get
            {
                return "Index - My ASP.NET Application";
            }
        }

        [FindsBy(How = How.Id, Using = "ThisCrazyId")]
        private IWebElement CreateNew { get; set; }


        public CreateMoviesPage CreateNewMovie()
        {
            CreateNew.Click();
            return GetInstance<CreateMoviesPage>();
        }
    }
}
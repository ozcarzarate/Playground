using MVC_Playground.PageLibrary;
using MVC_Playground.PageLibrary.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace MVC_Playground.Tests.Steps
{
    [Binding]
    public class CreateNewMovieSteps : TestFixtureBase
    {

        [Given(@"I have navigated to Create New Movie Page")]
        public void GivenIHaveNavigatedToCreateNewMoviePage()
        {
            var homePage = HomePage.LoadHomePage(CurrentDriver, MvcPlaygroundSettings.CurrentSettings.BaseUrl);
            var moviePage = homePage.NavigateToMovies();
            CurrentPage = moviePage.CreateNewMovie();
        }

        [Given(@"I have filled in all the Name of the movie with (.*)")]
        public void GivenIHaveFilledInAllTheNameOfTheMovieWith(string movieName)
        {
            var newMoviePage = (CreateMoviesPage)CurrentPage;
            newMoviePage.NameTextBox.SendKeys(movieName);
        }

        [When(@"I press the Create Button")]
        public void WhenIPressTheCreateButton()
        {
            var newMoviePage = (CreateMoviesPage)CurrentPage;
            CurrentPage = newMoviePage.ClickOnCreate();
        }

        [Then(@"The new movie is created and I am redirected to List of Movies and (.*) is in the list")]
        public void ThenTheNewMovieIsCreatedAndIAmRedirectedToListOfMoviesAndIsInTheList(string movieName)
        {
            Assert.AreEqual("Index - My ASP.NET Application", CurrentPage.DefaultTitle);
            var actual = CurrentPage.Driver.FindElement(By.XPath("//td[contains(.,'" + movieName + "')]")).Text;
            Assert.AreEqual(movieName, actual);
        }

    }
}

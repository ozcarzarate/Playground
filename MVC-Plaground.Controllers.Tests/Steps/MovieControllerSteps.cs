using DomainModel.Model;
using DomainModel.Repositories;
using Moq;
using MVC_Playground.Controllers;
using NUnit.Framework;
using System.Collections.Generic;
using System.Web.Mvc;
using TechTalk.SpecFlow;

namespace MVC_Plaground.Controllers.Tests.Steps
{
    [Binding]
    public class MovieControllerSteps
    {
        private Mock<IMoviesRepository> _mockMoviesRepository;
        private MoviesController _sut;
        private ViewResult _actual;

        [Given(@"I have created a Movie Controller")]
        public void GivenIHaveCreatedAMovieController()
        {
            _mockMoviesRepository = new Mock<IMoviesRepository>();
            _mockMoviesRepository.Setup(x => x.GetAll()).Returns(new List<Movie>());
            _sut = new MoviesController(_mockMoviesRepository.Object);
        }

        [When(@"I call Index Method")]
        public void WhenICallIndexMethod()
        {
            _actual = (ViewResult)_sut.Index();
        }

        [Then(@"I received a View")]
        public void ThenIReceivedAView()
        {
            Assert.IsNotNull(_actual);
        }


        [Given(@"asd asd asd")]
        public void GivenAsdAsdAsd()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"something")]
        public void WhenSomething()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"someother thing")]
        public void ThenSomeotherThing()
        {
            ScenarioContext.Current.Pending();
        }

    }
}

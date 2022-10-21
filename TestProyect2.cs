using FakeItEasy;
using flor.Controllers;
using flor.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NSubstitute.ReturnsExtensions;
using flor.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace TestProject1
{
    public class TramoTest_Fail
    {
        private readonly TramoController _controller;
        private readonly ITramoRepository _service;
        // private const string ConnectionString = @"Server=(10.0.100.100)\mssqllocaldb;Database=EFTestSample;Trusted_Connection=True";

        public TramoTest_Fail()
        {
            //Arrange
            _service = A.Fake<ITramoRepository>();
            _controller = new TramoController(_service);
        }


        [Fact]
        public void TestGetTramoByID()
        {
            var result = _controller.GetTramoById(1);
            result.Should().ReturnsNull();
          
        }


        [Fact]
        public void TestGetTramoByID_noExist()
        {

            int id = 5298;
            var result = _controller.GetTramoById(id);
            var tramo = Assert.IsAssignableFrom<Tramo>(result?.Value);
            //Assert.True(tramo != null);
            Assert.Equal(tramo?.Id, id);

        }

        [Fact]
        public void GetAllTramos_ShouldReturnAllTramos()
        {
            var testTramo = _controller.GetTramoList();
            var controller = new TramoController(_service);

            var result = (IEnumerable<Tramo>)controller.GetTramoList();
            Assert.NotEqual(testTramo.Count(), result.Count());
        }

       [Fact]
        public void GetTramo_ShouldNotFindTramo()
        {
            var controller = new TramoController(_service);

            var result = controller.GetTramoById(0);
            Assert.IsType( typeof(NotFoundResult), result);
        }

    
    }

    public class FailGeometriaControllerIntegrationTests : IClassFixture<TestingWebAppFactory<Program>>
    {
        private readonly HttpClient _client;//evitar la repetición de la creación de un cliente en cada prueba

        public FailGeometriaControllerIntegrationTests(TestingWebAppFactory<Program> factory)
            => _client = factory.CreateDefaultClient();



        [Theory]//probando multiples puntos finales a la vez
         [InlineData("/api/Geometria/5")]/* ---> :( no tendria que funcionar */
        public async Task Geometria_Called_ReturnsCreate_varios(string endpoint)
        {
            var response = await _client.GetAsync(endpoint);
            response.EnsureSuccessStatusCode();
           //  response.StatusCode.Should().Be(HttpStatusCode.OK);
            Assert.Equal("/api/Geometria/5", response.ToString());


        }

    }
}


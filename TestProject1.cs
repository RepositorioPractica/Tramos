using flor.Entities;
using Xunit;
using flor.Repositories;
using flor.Interfaces;
using flor.Controllers;
using Xunit.Sdk;
using FluentAssertions;
using FakeItEasy;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Reflection.Metadata;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using Newtonsoft.Json.Linq;
using TestProject1;
using System.Text.Json;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace TestProject1
{
    /// <summary>
    /// PRUEBA UNITARIA ///////////////////////////////////////
    /// </summary>
    public class TramoTest
    {
        private readonly TramoController _controller;
        private readonly ITramoRepository _service;
        // private const string ConnectionString = @"Server=(10.0.100.100)\mssqllocaldb;Database=EFTestSample;Trusted_Connection=True";

        public TramoTest()
        {
            //Arrange
            _service = A.Fake<ITramoRepository>();
            _controller = new TramoController(_service);
        }

        [Fact]

        public void TestGetTramo()
        {

            ///Act
            var result = _controller.GetTramoList();
            //Assert 
  
            Assert.NotNull(result);

        }


        [Fact]

        public void GetAllTramos_ShouldReturnAllTramos()
        {
            var testTramo = _controller.GetTramoList();
            var controller = new TramoController(_service);

            var result = (IEnumerable<Tramo>)controller.GetTramoList();
            Assert.Equal(testTramo.Count(), result.Count());
        }


        [Fact]
        public void TestGetTramoByID()
        {
            var result = _controller.GetTramoById(1);
            // Assert.IsType<Tramo>(result);
            Assert.NotNull(result);
        }


       /* [Fact]

        public void TestGetTramoByID_NotFound()
        {
            int id = 0;
            var result = _controller.GetTramoById(id);
            var tramo = Assert.IsAssignableFrom<Tramo>(result?.Value);
        }*/

        [Fact]

        public void GetCantidad()
        {
            var result = _controller.GetTramoList();
            var tramo = Assert.IsAssignableFrom<IEnumerable<Tramo>>(result);
            //Assert.///mirar aqui TODO
        }

    }

    ///////////////////////////////////
    public class GeometriaTest
    {
        private readonly GeometriaController _controller;
        private readonly IGeometriaRepository _service;

        public  GeometriaTest()
        {
            //Arrange
            _service = A.Fake<IGeometriaRepository>();
            _controller = new GeometriaController(_service);
        }

        [Fact]
        public void TestGetGeometriaById()
        {
            var id = 120;
            ///Act
            var result = _controller.GetGeometriaById(id);
            //Assert 
            Assert.NotNull(result);
        }

        [Fact]

        public void GetAllGeometria_ShouldReturnAllTramos()
        {
            var testTramo = _controller.GetGeometriaList();
            var controller = new GeometriaController(_service);

            var result = (IEnumerable<Geometria>)controller.GetGeometriaList();
            Assert.Equal(testTramo.Count(), result.Count());
        }


    }
    /// <summary>
    /// PRUEBA DE INTEGRACION ///////////////////////////////////////
    /// </summary>
    public class TramoControllerIntegrationTests : IClassFixture<TestingWebAppFactory<Program>>
    {
        private readonly HttpClient _client;//evitar la repetición de la creación de un cliente en cada prueba

        public TramoControllerIntegrationTests(TestingWebAppFactory<Program> factory)
            => _client = factory.CreateDefaultClient();


        [Fact] /*PRUEBA BASICA */
        public async Task Tramo_WhenCalled_ReturnsApplication()
        {
            var response = await _client.GetAsync("/api/Tramo");
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }


        [Theory]//probando multiples puntos finales a la vez
        [InlineData("/api/Tramo")]//parametrizar nuestra pruebas 
        [InlineData("/api/Tramo?id=1")]/* ---> :) si funciona */
       // [InlineData("api/Tramo?id=999999")]/* ---> :( no tendria que funcionar */
        public async Task Tramo_Called_ReturnsCreate_varios(string endpoint)
        {         
                var response = await _client.GetAsync(endpoint);
                response.EnsureSuccessStatusCode();
            // response.StatusCode.Should().Be(HttpStatusCode.OK);
            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());


        }

        /* [Fact]
         public async Task GET_retrieves_tramo()
         {
             var response = await _client.GetAndDeserialize("api/Tramo");//TODO ver
             response.Should().HaveCount(7);
         
    }*/

    }


     

    
        
}
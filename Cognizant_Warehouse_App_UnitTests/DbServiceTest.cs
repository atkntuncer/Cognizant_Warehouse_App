using AutoFixture;
using Cognizant_Warehouse_App.Business;
using Cognizant_Warehouse_App.Model;
using Cognizant_Warehouse_App.Repository;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Cognizant_Warehouse_App_UnitTests
{
    public class DbServiceTest
    {
        private readonly DbService _service;
        private readonly Mock<IBaseRepository> _repository=new();
        private readonly IFixture _fixture = new Fixture();
        private readonly Mock<ILogger<DbService>> _logger=new();
       
        public DbServiceTest()
        {
            _service = new DbService(_repository.Object,_logger.Object);
        }

        [Fact]
        public async Task GetVehiclesAsync_ShouldReturnVehicle_WhenWorks()
        {
            //Arrange
            var fixture = _fixture.Create<Vehicle>();
            List<Vehicle> vehicleList = new List<Vehicle>();
            vehicleList.Add(fixture);
            _repository.Setup(x => x.ReadAsync<Vehicle>(It.IsAny<string>())).ReturnsAsync(vehicleList);

            //Act
            var result = await _service.GetVehiclesAsync();

            //Assert
            result.Should().Contain(fixture);
        }


        [Fact]
        public async Task GetVehiclesAsync_ShouldReturnNull_WhenDoesntWorks()
        {
            //Arrange
            _repository.Setup(x => x.ReadAsync<Vehicle>(It.IsAny<string>())).ReturnsAsync(()=>null);

            //Act
            var result = await _service.GetVehiclesAsync();

            //Assert
            result.Should().BeNullOrEmpty();
        }

        [Fact]
        public async Task GetVehiclesIntheCartAsync_ShouldReturnVehicle_WhenWorks()
        {
            //Arrange
            var fixture = _fixture.Create<Vehicle>();
            List<Vehicle> vehicleList = new List<Vehicle>();
            vehicleList.Add(fixture);
            _repository.Setup(x => x.ReadAsync<Vehicle>(It.IsAny<string>())).ReturnsAsync(vehicleList);

            //Act
            var result = await _service.GetVehiclesIntheCartAsync();

            //Assert
            result.Should().Contain(fixture);
        }

        [Fact]
        public async Task GGetVehiclesIntheCartAsync_ShouldReturnNull_WhenDoesntWorks()
        {
            //Arrange
            _repository.Setup(x => x.ReadAsync<Vehicle>(It.IsAny<string>())).ReturnsAsync(()=>null);

            //Act
            var result = await _service.GetVehiclesIntheCartAsync();

            //Assert
            result.Should().BeNullOrEmpty();
        }
 
    }
}


using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Radar.API.Controllers;
using Radar.Library;
using Radar.Library.Interfaces;
using Radar.Library.Models.Binding;
using Radar.Library.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Radar.Testing
{
    public class VehicleControllerTesting
    {
        private Mock<ILogger<VehicleController>> _logger;
        private Mock<IRepositoryWrapper> repoMock;
        private VehicleController vehicleController;
        private AddVehicle addVehicle;
        private UpdateVehicle updateVehicle;
        private Vehicle vehicle;
        private List<Vehicle> vehicles;
        private Mock<IVehicle> vehicleMock;
        private List<IVehicle> vehiclesMock;
        private Mock<IAddVehicle> addVehicleMock;
        private Mock<IUpdateVehicle> updateVehicleMock;
        private Mock<IVehicleViewModel> vehicleViewModelMock;
        private List<IVehicleViewModel> vehiclesViewModelMock;
        private Mock<IAlert> alertMock;
        
        public VehicleControllerTesting()
        {
            //mock setup
            vehicleMock = new Mock<IVehicle>();
            vehiclesMock = new List<IVehicle> { vehicleMock.Object };
            addVehicleMock = new Mock<IAddVehicle>();
            updateVehicleMock = new Mock<IUpdateVehicle>();
            vehicle = new Vehicle();
            vehicles = new List<Vehicle>();

            //view models mock setup
            vehicleViewModelMock = new Mock<IVehicleViewModel>();
            vehiclesViewModelMock = new List<IVehicleViewModel>();

            //sample models
            addVehicle = new AddVehicle { Latitude = 10, Longitude = 10, VehicleHumidity = 10, VehicleTemp = 10 };
            updateVehicle = new UpdateVehicle { Latitude = 12, Longitude = 10, VehicleHumidity = 10, VehicleTemp = 10 };

            //controller setup
            _logger = new Mock<ILogger<VehicleController>>();
            repoMock = new Mock<IRepositoryWrapper>();
            alertMock = new Mock<IAlert>();
            var allVehicles = GetVehicles();
            var onevehicle = GetVehicle();
            vehicleController = new VehicleController(_logger.Object, repoMock.Object);


        }
        private IEnumerable<Vehicle> GetVehicles()
        {
            var vehicles = new List<Vehicle>
            {
                new Vehicle(){VehicleID=Guid.NewGuid(),Latitude=10,Longitude=10,VehicleHumidity=10,VehicleTemp=10},
                new Vehicle(){VehicleID=Guid.NewGuid(),Latitude=20,Longitude=30,VehicleHumidity=30,VehicleTemp=15}
            };
            return vehicles;
        }
        private Vehicle GetVehicle()
        {
            return GetVehicles().ToList()[0];
        }
            [Fact]
        public void GetAllVehicles_Test()
        {
            //Arrange
            repoMock.Setup(repo => repo.Vehicle.FindAll()).Returns(GetVehicles());
            //Action
            var controllerActionResult = vehicleController.AllVehicleStatuses();
            //Assert
            Assert.NotNull(controllerActionResult);
        }
        /*[Fact]
        public void GetVehicle_Test()
        {
            //Arrange
            repoMock.Setup(repo => repo.Vehicle.FindByCondition(c => c.VehicleID == It.IsAny<Guid>())).Returns(GetVehicles());
            //Action
            var controllerActionResult = vehicleController.VehicleStatus(It.IsAny<Guid>());
            //Assert
            Assert.NotNull(controllerActionResult);
        }*/

        [Fact]
        public async void AddVehicle_Test()
        {
            //Arrange
           /* repoMock.Setup(repo => repo.Vehicle.FindByCondition(
                c => c.VehicleID == It.IsAny<Guid>())).*/
                //Returns(GetVehicles());
            repoMock.Setup(repo => repo.Vehicle.Create(vehicle)).Returns(vehicle);

            //Action
            var controllerActionResult = await vehicleController.AddVehicle(addVehicle);
            //Assert
            Assert.NotNull(controllerActionResult);
            Assert.IsType<ActionResult<Vehicle>>(controllerActionResult);
        }
        /*// Arrange
        var mockRepo = new Mock<IBrainstormSessionRepository>();
        mockRepo.Setup(repo => repo.AddAsync(It.IsAny<BrainstormSession>()))
        .Returns(Task.CompletedTask)
        .Verifiable();
        var controller = new HomeController(mockRepo.Object);
        var newSession = new HomeController.NewSessionModel()
        {
            SessionName = "Test Name"
        };

        // Act
        var result = await controller.Index(newSession);

        // Assert
        var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
        Assert.Null(redirectToActionResult.ControllerName);
    Assert.Equal("Index", redirectToActionResult.ActionName);*/
    //mockRepo.Verify();



        

    }
}

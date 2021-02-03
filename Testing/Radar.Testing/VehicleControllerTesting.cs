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
            updateVehicle = new UpdateVehicle { Latitude = 999, Longitude = 999, VehicleHumidity = 60, VehicleTemp = 80 };
            
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
            return GetVehicles().ToList().FirstOrDefault();
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

    
        [Fact]
        public void GetVehicleStatus_Test()
        {
            // Arrrange
            var vehicleId = GetVehicle().VehicleID;
            repoMock.Setup(repo => repo.Vehicle.FindByCondition(v => v.VehicleID == vehicleId)).Returns(GetVehicles());
            
            // Action
            var ControllerActionResult = vehicleController.VehicleStatus(vehicleId);

            // Assert
            Assert.NotNull(ControllerActionResult);
            Assert.IsType<ActionResult<VehicleViewModel>>(ControllerActionResult);
        }

      [Fact]
      public void AddVehicle_Test()
        {
            repoMock.Setup(v => v.Vehicle.Create(vehicle)).Returns(vehicle);
            var ControllerActionResult = vehicleController.AddVehicle(addVehicle);

            Assert.NotNull(ControllerActionResult);
            Assert.IsType<Task<ActionResult<VehicleViewModel>>>(ControllerActionResult);
        }
        
        [Fact]
        public void UpdateVehicle_Test()
        {
            // Arrage
            repoMock.Setup(repo => repo.Vehicle.FindByCondition(v => v.VehicleID == It.IsAny<Guid>())).Returns(GetVehicles());
            repoMock.Setup(repo => repo.Vehicle.Update(GetVehicle())).Returns(vehicle);

            // Action

            var ControllerActionResult = vehicleController.UpdateVehicleStatus(GetVehicle().VehicleID, updateVehicle);
        

            // Assert
            Assert.NotNull(ControllerActionResult);
            Assert.IsType<Task<ActionResult<VehicleViewModel>>>(ControllerActionResult);
        }


        [Fact]
        public void RemoveVehicle_Test()
        {
            //Arrange
            var vehicleToDelete = GetVehicle();
            repoMock.Setup(repo => repo.Vehicle.FindByCondition(v => v.VehicleID == vehicleToDelete.VehicleID)).Returns(GetVehicles());
            repoMock.Setup(repo => repo.Vehicle.Delete(vehicleToDelete));

            //Act
            var ControllerActionResult = vehicleController.RemoveVehicle(GetVehicle().VehicleID);

            //Assert
            
            Assert.NotNull(ControllerActionResult);
            var newLength = GetVehicles().ToList().Count;
            Assert.IsType<OkObjectResult>(ControllerActionResult);

        }

    }
}

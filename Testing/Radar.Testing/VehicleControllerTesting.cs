using Microsoft.Extensions.Logging;
using Moq;
using Radar.API.Controllers;
using Radar.Library;
using Radar.Library.Interfaces;
using Radar.Library.Models.Binding;
using System;
using System.Collections.Generic;
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
            //var allVehicles = GetAll();            
        }
        /*private IEnumerable<Vehicle> GetVehicles()
        {
            var vehicles=new List<Vehicle>
            {
                //new Vehicle(){VehicleID=}
            }
        }*/

        [Fact]
        public void GetAllVehicles_Test()
        {

        }
        /* public void GetAllCourses_Test()
         {
             //Arrange
             mockRepo.Setup(repo => repo.Courses.FindAll()).Returns(GetCourses());
             mockRepo.Setup(repo => repo.Registrations.FindByCondition(r => r.CourseId == It.IsAny<int>())).Returns(GetRegistrations());
             //Act
             var controllerActionResult = courseController.Get();
             //Assert
             Assert.NotNull(controllerActionResult);
         }
        private IEnumerable<Course> GetCourses()
         {
             var courses = new List<Course> {
             new Course(){Id=1, Code="CS101", Title="Computing Basics"},
             new Course(){Id=1, Code="CS102", Title="Computing Intermediate"}
             };
             return courses;
         }
         private Course GetCourse()
         {
             return GetCourses().ToList()[0];
         }*/
    }
}

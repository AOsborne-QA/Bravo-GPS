using Microsoft.Extensions.Logging;
using Moq;
using Radar.API.Controllers;
using Radar.API.Hubs;
using Radar.Library;
using Radar.Library.Interfaces;
using Radar.Library.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Radar.Testing
{
    public class AlertControllerTest
    {
        private Mock<ILogger<AlertController>> _logger;
        private Mock<IRepositoryWrapper> repoMock;
        private AlertController alertController;
        private Mock<AlertHub> alerthubMock;
        private Alert alert;
        private List<Alert> alerts;
        private Mock<IAlert> alertMock;
        private List<IAlert> alertsMock;
        private Mock<Vehicle> vehicle;
        private List<IVehicle> vehicles;
        public AlertControllerTest()
        {
            //mock setup
            alertMock = new Mock<IAlert>();
            alertsMock = new List<IAlert> { alertMock.Object };
            alert = new Alert();
            alerts = new List<Alert>();
            alerthubMock = new Mock<AlertHub>();
            vehicle = new Mock<Vehicle>();
            //controller setup
            _logger = new Mock<ILogger<AlertController>>();
            repoMock = new Mock<IRepositoryWrapper>();
            alertController = new AlertController(_logger.Object, repoMock.Object);

        }
        private IEnumerable<Alert> GetAlerts()
        {
            var alerts = new List<Alert> {
                new Alert() { }
            };
            return alerts;
        }

        /*[Fact]
        public void ViewAll()
        {

        }*/
    }
}

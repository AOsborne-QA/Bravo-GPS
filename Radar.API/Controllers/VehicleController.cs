using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Radar.API.Hubs;
using Radar.Library;
using Radar.Library.Interfaces;
using Radar.Library.Models.Binding;
using Radar.Library.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using Radar.Library.Utility;
using Radar.Library.Models.Entity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Radar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {

        private ILogger<VehicleController> _logger;
        private IRepositoryWrapper repository;
        private AlertUtility alertU;

        public VehicleController(ILogger<VehicleController> logger, IRepositoryWrapper repositoryWrapper)
        {
            _logger = logger;
            repository = repositoryWrapper;
            alertU = new AlertUtility(repositoryWrapper);

        }
        // GET: api/<VehicleController>

        // Get vehicle
        [HttpGet("status/all")]
        public IEnumerable<VehicleViewModel> AllVehicleStatuses()
        {
           

            var allVehicles = repository.Vehicle.FindAll();
            if (allVehicles == null)
            {
                _logger.LogWarning("There are no vehicles currently logged");
                return null;
            }
            else
            {
                List<VehicleViewModel> vehicles = new List<VehicleViewModel>();
                foreach (var vehicle in allVehicles)
                {
                    vehicles.Add(new VehicleViewModel() { Vehicle = vehicle });
                }
                _logger.LogInformation("Vehicles found for tracking. Result returned.");
                return vehicles;
            }
        }

        // GET api/<VehicleController>/5
        [HttpGet("status/{id}")]
        public ActionResult<Vehicle> VehicleStatus(Guid id)
        {
            var findVehicle = repository.Vehicle.FindByCondition(v => v.VehicleID == id).FirstOrDefault();
            if (findVehicle == null)
            {
                _logger.LogWarning("No vehicle with this ID has been found. Please recheck ID entered");
                return NotFound($"Vehicle with ID of {id} was not found. Please recheck ID entered");
            }
            _logger.LogInformation($"Vehicle with id {id} has been located and information outputted");
            return findVehicle;
        }

        // POST api/<VehicleController>
        [HttpPost("add")]
        public async Task<ActionResult<Vehicle>> AddVehicle([FromBody] AddVehicle addVehicle)
        {
            var newVehicle = repository.Vehicle.Create(new Vehicle
            {
                Latitude = addVehicle.Latitude,
                Longitude = addVehicle.Longitude,
                VehicleHumidity = addVehicle.VehicleHumidity,
                VehicleTemp = addVehicle.VehicleTemp
            });

            await alertU.PassAlert(newVehicle);
            repository.Save();
            _logger.LogInformation($"Vehicle has been successfully added with ID {newVehicle.VehicleID}.");
            return newVehicle;

        }


        // PUT api/<VehicleController>/5
        [HttpPut("update/{id}")]
        public async Task<ActionResult<Vehicle>> UpdateVehicleStatus(Guid id, [FromBody] UpdateVehicle updateVehicle)
        {

            var findVehicle = repository.Vehicle.FindByCondition(v => v.VehicleID == id).FirstOrDefault();
            repository.Vehicle.Update(findVehicle);
            if (findVehicle == null)
            {
                _logger.LogError($"No vehicle with {id} has been found. Please recheck input.");
                return NotFound($"No Vehicle with {id} has been found. Please recheck input.");
            }
            findVehicle.Latitude = updateVehicle.Latitude;
            findVehicle.Longitude = updateVehicle.Longitude;
            findVehicle.VehicleHumidity = updateVehicle.VehicleHumidity;
            findVehicle.VehicleTemp = updateVehicle.VehicleTemp;
            await alertU.PassAlert(findVehicle);
            repository.Save();
            _logger.LogInformation($"Vehicle id: {id} has updated information");
            return Ok($"Vehicle id: {id} has updated information");
        }

    // DELETE api/<VehicleController>/5
    [HttpDelete("remove/{id}")]
    public IActionResult RemoveVehicle(Guid id)
    {
            var findVehicle = repository.Vehicle.FindByCondition(v => v.VehicleID == id).FirstOrDefault();
            if (findVehicle == null)
            {
                _logger.LogError($"No vehicle with {id} has been found. Please recheck input.");
                return NotFound($"No Vehicle with {id} has been found. Please recheck input.");
            }
            _logger.LogInformation($"Removing vehicle id {id} from tracking.");
            repository.Vehicle.Delete(findVehicle);
            repository.Save();
            _logger.LogInformation($"Vehicle with {id} is no longer tracked and has been removed.");
            return Ok($"Vehicle with {id} is no longer tracked and has been removed.");
        }
}
}

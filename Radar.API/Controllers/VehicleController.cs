using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Radar.Library.Interfaces;
using Radar.Library.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Radar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private ILogger<VehicleController> _logger;
        private IRepositoryWrapper repository;

        public VehicleController(ILogger<VehicleController> logger, IRepositoryWrapper repositoryWrapper)
        {
            _logger = logger;
            repository = repositoryWrapper;
        }
        // GET: api/<VehicleController>

        // Get vehicle
        [HttpGet]
        public IEnumerable<VehicleViewModel> AllVehicleStatuses()
        {
            var allVehicles = repository.Vehicle.FindAll();
            if (allVehicles.Count() == 0)
            {
                _logger.LogError("There are no vehicles currently logged");
                return null;
            }
            else
            {
                List<VehicleViewModel> vehicles = new List<VehicleViewModel>();
                foreach (var vehicle in allVehicles)
                {
                    vehicles.Add(new VehicleViewModel() { Vehicle = vehicle });
                }
                _logger.LogInformation("Vehicles found for tracking. Reult returned.");
                return vehicles;
            }
        }

        // GET api/<VehicleController>/5
        [HttpGet("{id}")]
        public ActionResult<Vehicle> VehicleStatus(int id)
        {
            return NotImplementedException;
        }

        // POST api/<VehicleController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<VehicleController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<VehicleController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

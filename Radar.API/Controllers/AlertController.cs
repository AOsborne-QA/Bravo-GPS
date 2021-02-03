using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Radar.Library.Interfaces;
using Radar.Library.Models.Entity;
using Radar.Library.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Radar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlertController : ControllerBase
    {
        private ILogger<AlertController> _logger;
        private IRepositoryWrapper repository;
        public AlertController(ILogger<AlertController> logger, IRepositoryWrapper repositoryWrapper)
        {
            _logger = logger;
            repository = repositoryWrapper;
        }

        // GET: api/<AlertController>
        [HttpGet("view/all")]
        public IEnumerable<AlertViewModel> ViewAll()
        {
            var allAlerts = repository.Alert.FindAll();

            if (allAlerts == null)
            {
                _logger.LogWarning("There are no alerts currently logged");
                return null;
            }
            else
            {
                List<AlertViewModel> alertViewModels = new List<AlertViewModel>();
                foreach (var alert in allAlerts)
                {
                    alertViewModels.Add(new AlertViewModel() { Alert = alert });
                }
                _logger.LogInformation("Alerts found and returned.");
                return alertViewModels;
            }

        }

        // GET api/<AlertController>/5
        [HttpGet("view/{id}")]
        public ActionResult<AlertViewModel> ViewAlert(int id)
        {
            var findAlert = repository.Alert.FindByCondition(a => a.ID == id).FirstOrDefault();

            if (findAlert == null)
            {
                _logger.LogWarning($"Unable to locate alert with id {id}. Please recheck input.");
                return NotFound($"Unable to locate alert with id {id}. Please recheck input.");
            }
            var foundAlertViewModel = new AlertViewModel { Alert = findAlert };
            _logger.LogInformation($"Alert with id {id} has been found and information outputted");
            return foundAlertViewModel;
        }

    }
}

﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Logging;
using Radar.Library.Interfaces;
using Radar.Library.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            GetConnection();
        }

        public async void GetConnection()
        {
            HubConnection hub = new HubConnectionBuilder().WithUrl("https://localhost:44383/alertHub").Build();
            try
            {
                //tries an initial connection
                await hub.StartAsync();
            }
            catch(Exception exc)
            {

            }
        }

        // GET: api/<AlertController>
        [HttpGet("view/all")]
        public IEnumerable<Alert> ViewAll()
        {
            var allAlerts = repository.Alert.FindAll();

            if (allAlerts == null)
            {
                _logger.LogWarning("There are no alerts currently logged");
                return null;
            }
            else
            {
                List<Alert> alerts = new List<Alert>();
                foreach (var alert in allAlerts)
                {
                    alerts.Add(alert);
                }
                _logger.LogInformation("Alerts found and returned.");
                return alerts;
            }

        }

        // GET api/<AlertController>/5
        [HttpGet("view/{id}")]
        public ActionResult<Alert> ViewAlert(int id)
        {
            var findAlert = repository.Alert.FindByCondition(a => a.ID == id).FirstOrDefault();

            if (findAlert == null)
            {
                _logger.LogWarning($"Unable to locate alert with id {id}. Please recheck input.");
                return NotFound($"Unable to locate alert with id {id}. Please recheck input.");
            }
            _logger.LogInformation($"Alert with id {id} has been found and information outputted");
            return findAlert;
        }

        // POST api/<AlertController>
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }

        // PUT api/<AlertController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AlertController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR.Client;
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


        // GET: api/<AlertController>
        [HttpGet]
        public async Task<IEnumerable<string>> Get()
        {
             HubConnection hub = new HubConnectionBuilder().WithUrl("https://localhost:44383/alertHub").Build();
            //This is for checking if the signal r works not permanent

            try
            {
                //tries an initial connection
                await hub.StartAsync();
                //puts the message in the connection box

            }
            catch (Exception exc)
            {
                //puts the error message in the connection box if the connection fails

            }
            await hub.InvokeAsync("SendAlert", "vechID", "Red", "Temperature", DateTime.Now);
            return new string[] { "value1", "value2" };
        }

        // GET api/<AlertController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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

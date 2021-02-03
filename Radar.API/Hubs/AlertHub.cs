using Microsoft.AspNetCore.SignalR;
using Radar.Library.Models.Entity;
using System;
using System.Threading.Tasks;

namespace Radar.API.Hubs
{
    public class AlertHub : Hub
    {
        //This gets the connection on the hub and does what it needs to when it connects
        public async override Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
        }
        //This calls the methods that work when the client is disconnected from the hub
        public async override Task OnDisconnectedAsync(Exception exception)
        {
            await base.OnDisconnectedAsync(exception);
        }

        //This defines a method that can be called by the API
        public async Task SendAlert(Alert alert)
        {
            await Clients.All.SendAsync("RecieveAlert", alert);
        }
        
        
    }
}

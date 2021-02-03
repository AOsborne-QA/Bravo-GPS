using Microsoft.AspNetCore.SignalR;
using Radar.Library.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
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

        //This defines a method that can be called by the API (i think for now that's how it will work)
        public async Task SendAlert(Alert alert)
        {
            await Clients.All.SendAsync("RecieveAlert", alert);
        }
        
        //This sends message to client to run AllAlerts
        public async Task GetAlerts(Guid clientId)
        {
            await Clients.Client("Server").SendAsync("AllAlerts", clientId);
        }

        public async Task SendAllAlert(Guid clientId, List<Alert> alerts)
        {
            await Clients.Client(clientId.ToString()).SendAsync("ReceiveAllAlerts", alerts);
        }
    }
}

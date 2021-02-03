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

        //This defines a method that can be called by the API
        public async Task SendAlert(Alert alert)
        {
            await Clients.All.SendAsync("RecieveAlert", alert);
        }
        
       /* -----To be used for future implementation between desktop and client---------
        public async Task GetAlerts(Guid clientId)
        {
            await Clients.Groups("Server").SendAsync("AllAlerts", clientId);
        }

        public async Task SendAllAlert(Guid clientId, List<Alert> alerts)
        {
            await Clients.Client(clientId.ToString()).SendAsync("ReceiveAllAlerts", alerts);
        }

        public async Task JoinGroup(string group)
        {
            await Groups.AddToGroupAsync(this.Context.ConnectionId, "group");
        }*/

        
    }
}

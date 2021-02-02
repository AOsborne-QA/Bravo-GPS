using Microsoft.AspNetCore.SignalR;
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
        //THis calls the methods that work when the client is disconnected from the hub
        public async override Task OnDisconnectedAsync(Exception exception)
        {
            await base.OnDisconnectedAsync(exception);
        }

        //This defines a method that can be called by the API (i think for now that's how it will work)
        public async Task SendAlert(String vehicleID, String alertColour, String alertType, DateTime timeStamp)
        {
            await Clients.All.SendAsync("RecieveAlert", vehicleID, alertColour, alertType,timeStamp);
        }
        
    }
}

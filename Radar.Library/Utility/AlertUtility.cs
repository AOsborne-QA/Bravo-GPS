using Microsoft.AspNetCore.SignalR.Client;
using Radar.Library.Interfaces;
using Radar.Library.Models.Entity;
using Radar.Library.Models.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radar.Library.Utility
{
    public class AlertUtility
    {
        private IRepositoryWrapper repository;

        public AlertUtility(IRepositoryWrapper repositoryWrapper)
        {
            repository = repositoryWrapper;
        }
  
        public Alert RetrieveHumidityAlert(Vehicle y)
        {
            Alert alert = CreateAlert(y);
            alert.AlertType = "Humidity";
            if (y.VehicleHumidity > 60 || y.VehicleHumidity < 20)
            {
                alert.AlertColour="Red";
                SaveAlert(alert);
            }
            else if ((y.VehicleHumidity >= 21 && y.VehicleHumidity <= 30)
                || (y.VehicleHumidity >= 40 && y.VehicleHumidity <= 60))
            {
                // (Humidity) Alert is set to amber
                alert.AlertColour ="Amber";

            }
            else
            {
                // (Humidity) Alert is set to green
                alert.AlertColour = "Green";
            }

            return alert;
        }

        public Alert RetrieveTempAlert(Vehicle x)
        {
            Alert alert = CreateAlert(x);
            alert.AlertType = "Humidity";
            if (x.VehicleTemp > 25 || x.VehicleTemp < -60)
            {
                // (Temp) Alert is set to red
                alert.AlertColour = "Red";
                SaveAlert(alert);
            }
            else if ((x.VehicleTemp >= -60 && x.VehicleTemp <= -15)
                || (x.VehicleTemp >= 16 && x.VehicleTemp <= 25))
            {
                // (Temp) Alert is set to amber
                alert.AlertColour="Amber";
            }
            else
            {
                // (Temp) Alert is set to green
                alert.AlertColour = "Green";
            }
            return alert;
        }
        public static async Task<string> SendAlert(Alert alert)
        {
            HubConnection hub = new HubConnectionBuilder().WithUrl("https://localhost:44383/alertHub").Build();
            try
            {
                //tries an initial connection
                await hub.StartAsync();
            }
            catch (Exception exc)
            {
                return exc.Message;
            }
            await hub.InvokeAsync("SendAlert", alert);
            return ($"A {alert.AlertColour} {alert.AlertType} has been sent");   
        }

        public Alert CreateAlert(Vehicle v)
        {
            Alert alert = new Alert()
            {
                VehicleID = v.VehicleID,
                AlertTime = DateTime.Now,
                VehicleHumidity = v.VehicleHumidity,
                VehicleTemp = v.VehicleTemp,
                Longitude = v.Longitude,
                Latitude = v.Latitude,
                vehicle = v
            };
            return alert;
        }

        public Alert SaveAlert(Alert a)
        {
            repository.Alert.Create(a);
            repository.Save();
            return a;
        }

        public async Task<string> PassAlert(Vehicle v)
        {
            Alert tAlert = RetrieveTempAlert(v);
            await SendAlert(tAlert);
            Alert hAlert = RetrieveHumidityAlert(v);
            await SendAlert(hAlert);
            return ($"{tAlert.AlertColour} {tAlert.AlertType}   {tAlert.AlertColour} {tAlert.AlertType}  recorded");
        }
        
    }
}

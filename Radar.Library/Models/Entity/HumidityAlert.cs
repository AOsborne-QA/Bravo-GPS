using System;
using System.Collections.Generic;
using System.Text;

namespace Radar.Library.Models.Entity
{
    class HumidityAlert
    {
        public string RetrieveHumidityAlert(Vehicle y)
        {
            if (y.VehicleHumidity > 60 || y.VehicleHumidity < 20)
            {
                // (Humidity) Alert is set to red
                return "Red";
            }
            else if ((y.VehicleHumidity >= 21 && y.VehicleHumidity <= 30)
                || (y.VehicleHumidity >= 40 && y.VehicleHumidity <= 60))
            {
                // (Humidity) Alert is set to amber
                return "Amber";
            }
            else
            {
                // (Humidity) Alert is set to green
                return "Green";
            }

        }
    }
}

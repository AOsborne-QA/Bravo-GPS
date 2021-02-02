using Radar.Library.Models.Entity;
using Radar.Library.Models.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radar.Library.Utility
{
    public static class AlertUtility
    {
        public static Alert RetrieveHumidityAlert(Vehicle y)
        {
            Alert Alert = new Alert() {
                VehicleID = y.VehicleID
            };
            if (y.VehicleHumidity > 60 || y.VehicleHumidity < 20)
            {
                // (Humidity) Alert is set to red
                Alert.AlertColour="Red";
                Alert.AlertType = "Humidity";

                //Some method to send a red alert
            }
            else if ((y.VehicleHumidity >= 21 && y.VehicleHumidity <= 30)
                || (y.VehicleHumidity >= 40 && y.VehicleHumidity <= 60))
            {
                // (Humidity) Alert is set to amber
                Alert.AlertColour ="Amber";
                Alert.AlertType = "Humidity";
            }
            else
            {
                // (Humidity) Alert is set to green
                Alert.AlertColour = "Green";
            }

            return Alert;

        }

        public static TempAlert RetrieveTempAlert(Vehicle x)
        {
            TempAlert tempAlert = new TempAlert()
            {
                VehicleID = x.VehicleID
            };
            if (x.VehicleTemp > 25 || x.VehicleTemp < -60)
            {
                // (Temp) Alert is set to red
                tempAlert.AlertColour = "Red";
            }
            else if ((x.VehicleTemp >= -60 && x.VehicleTemp <= -15)
                || (x.VehicleTemp >= 16 && x.VehicleTemp <= 25))
            {
                // (Temp) Alert is set to amber
                tempAlert.AlertColour="Amber";
            }
            else
            {
                // (Temp) Alert is set to green
                tempAlert.AlertColour = "Green";
            }
            return tempAlert;
        }
    }
}

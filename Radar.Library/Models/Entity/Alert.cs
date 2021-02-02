using Radar.Library.Models.Properties;
using System;
using System.Collections.Generic;
using System.Text;

namespace Radar.Library.Models.Entity
{
    public class Alert : VehicleInfo
    {
        public int ID { get; set; }

        public Guid VehicleID { get; set; }

        // AlertType references Humidity or Temperature alert
        public string AlertType { get; set; }

        public DateTime AlertTime
        {
            get { return AlertTime; }
            set { AlertTime = DateTime.Now; }
        }
        // Red, Amber, or Green
        public string AlertColour { get; set; }


        public static string RetrieveTempAlert(Vehicle vehicleObject)
        {
            if (vehicleObject.VehicleTemp > 25 || vehicleObject.VehicleTemp < -60)
            {
                // (Temp) Alert is set to red
                return "Red";
            }
            else if ((vehicleObject.VehicleTemp >= -60 && vehicleObject.VehicleTemp <= -15)
                || (vehicleObject.VehicleTemp >= 16 && vehicleObject.VehicleTemp <= 25))
            {
                // (Temp) Alert is set to amber
                return "Amber";
            }
            else
            {
                // (Temp) Alert is set to green
                return "Green";
            }

        }

        public static string RetrieveHumidityAlert(Vehicle vehicleObject)
        {
            if (vehicleObject.VehicleHumidity > 60 || vehicleObject.VehicleHumidity < 20)
            {
                // (Humidity) Alert is set to red
                return "Red";
            }
            else if ((vehicleObject.VehicleHumidity >= 21 && vehicleObject.VehicleHumidity <= 30)
                || (vehicleObject.VehicleHumidity >= 40 && vehicleObject.VehicleHumidity <= 60))
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

        public static string RetrieveAlertType(Vehicle vehicleObject)
        {
            if(vehicleObject.AlertType = "Temperature")
            {

                RetrieveTempAlert(Vehicle vehicleObject);
            }
            else if (vehicleObject.AlertType = "Humidity")
            {
                RetrieveHumidityAlert(Vehicle vehicleObject);
            }

        }
    }
}

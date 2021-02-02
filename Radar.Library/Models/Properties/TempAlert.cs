using Radar.Library.Models.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Radar.Library.Models.Properties
{
    public class TempAlert : Alert
    {
        public string RetrieveTempAlert(Vehicle x)
        {
            if(x.VehicleTemp > 25 || x.VehicleTemp < -60)
            {
                // (Temp) Alert is set to red
                return "Red";
            }
            else if((x.VehicleTemp >= -60 && x.VehicleTemp <= -15)
                || (x.VehicleTemp >= 16 && x.VehicleTemp <=25 ))
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
        
    }
}

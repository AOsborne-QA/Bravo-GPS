using Radar.Library.Models.Properties;
using System;
using System.Collections.Generic;
using System.Text;

namespace Radar.Library.Models.Entity
{
    public class Alert : VehicleInfo
    {
        public Guid VehicleID { get; set; }
        public DateTime AlertTime 
        {
            get { return AlertTime; }
            set { AlertTime = DateTime.Now; }
        }

        
    }
}

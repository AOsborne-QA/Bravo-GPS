using Radar.Library.Models.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Radar.Library.Models.Entity
{
    public class Alert : VehicleInfo
    {
        public int ID { get; set; }
        public Vehicle vehicle { get; set; }
        [ForeignKey("Vehicle")]
        public Guid VehicleID { get; set; }
        public DateTime AlertTime { get; set; }
        // Red, Amber, or Green
        public string AlertColour { get; set; }
        public string AlertType { get; set; }
    }
}

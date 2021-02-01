using System;
using System.Collections.Generic;
using System.Text;

namespace Radar.Library.Models.Entity
{
    public class VehicleInfo
    {
        public GPS Location { get; set; }
        public float VehicleTemp { get; set; }
        public float VehicleHumidity { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Radar.Library.Interfaces
{
    public interface IVehicle:IVehicleInfo
    {
        public Guid VehicleID { get; set; }
    }
}

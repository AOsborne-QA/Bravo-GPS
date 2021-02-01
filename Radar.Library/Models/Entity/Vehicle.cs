using System;
using System.ComponentModel.DataAnnotations;

namespace Radar.Library
{
    public class Vehicle
    {

        [Key]
        public Guid VehicleID { get; set; }

    }
}

using Radar.Library.Models.Entity;
using System;
using System.ComponentModel.DataAnnotations;

namespace Radar.Library
{
    public class Vehicle:VehicleInfo
    {

        [Key]
        public Guid VehicleID { get; set; }

    }
}

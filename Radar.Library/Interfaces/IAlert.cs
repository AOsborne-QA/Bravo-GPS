using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radar.Library.Interfaces
{
    public interface IAlert:IVehicleInfo
    {
        public int ID { get; set; }
        public Vehicle vehicle { get; set; }
        //[ForeignKey("Vehicle")]
        public Guid VehicleID { get; set; }
        public DateTime AlertTime { get; set; }
        // Red, Amber, or Green
        public string AlertColour { get; set; }
        public string AlertType { get; set; }
    }
}

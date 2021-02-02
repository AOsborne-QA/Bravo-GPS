using Radar.Library.Models.Entity;
using Radar.Library.Models.Properties;

namespace Radar.Library.Interfaces
{
    public interface IVehicleInfo
    {
        public GPS Location { get; set; }
        public float VehicleTemp { get; set; }
        public float VehicleHumidity { get; set; }
    }
}

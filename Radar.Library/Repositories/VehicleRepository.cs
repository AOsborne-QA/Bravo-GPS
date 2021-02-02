using Radar.Library.Data;
using Radar.Library.Interfaces;

namespace Radar.Library.Repositories
{
    public class VehicleRepository : Repository<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(ApplicationDbContext dbContext) : base(dbContext) { }
    }
    
}

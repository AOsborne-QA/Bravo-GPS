using Radar.Library.Data;
using Radar.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Radar.Library.Repositories
{
    public class VehicleRepository : Repository<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(ApplicationDbContext dbContext) : base(dbContext) { }
    }
    
}

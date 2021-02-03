using Radar.Library.Data;
using Radar.Library.Interfaces;
using Radar.Library.Models.Entity;

namespace Radar.Library.Repositories
{
    class AlertRepository : Repository<Alert>, IAlertRepository
    {
        public AlertRepository(ApplicationDbContext dbContext) : base(dbContext) { }
    }
}

using Radar.Library.Data;
using Radar.Library.Interfaces;

namespace Radar.Library.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        ApplicationDbContext _repoContext;
        public RepositoryWrapper(ApplicationDbContext repoContext)
        {
            _repoContext = repoContext;
        }
        IVehicleRepository _vehicles;
        IAlertRepository _alerts;
        public IVehicleRepository Vehicle
        {
            get
            {
                if (_vehicles == null)
                {
                    _vehicles = new VehicleRepository(_repoContext);
                }
                return _vehicles;
            }
        }

        public IAlertRepository Alert
        {
            get
            {
                if (_alerts == null)
                {
                    _alerts = new AlertRepository(_repoContext);
                }
                return _alerts;
            }
        }

        public void Save()
        {
            _repoContext.SaveChanges(); 
        }
    }
}

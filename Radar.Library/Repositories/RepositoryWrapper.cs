using Radar.Library.Data;
using Radar.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

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

        public void Save()
        {
            _repoContext.SaveChanges(); 
        }
    }
}

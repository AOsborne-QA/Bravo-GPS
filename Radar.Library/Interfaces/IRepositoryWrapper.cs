namespace Radar.Library.Interfaces
{
    public interface IRepositoryWrapper
    {  
        IVehicleRepository Vehicle { get; }
        IAlertRepository Alert { get; }
        void Save();
    }
}

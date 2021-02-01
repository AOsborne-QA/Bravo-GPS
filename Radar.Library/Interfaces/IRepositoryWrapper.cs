namespace Radar.Library.Interfaces
{
    public interface IRepositoryWrapper
    {  
        IVehicleRepository Vehicle { get; }
        void Save();
    }
}

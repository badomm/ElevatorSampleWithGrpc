using ElevatorSim;

namespace ElevatorServer.Services
{
    public interface IElevatorBrain
    {
        Task AddFromFloorRequest(FromFloorRequest request);
        Task AddToFloorRequest(ToFloorRequest request);
    }
}
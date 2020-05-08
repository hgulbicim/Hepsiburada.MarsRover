using Hepsiburada.MarsRover.Entities.Entity;

namespace Hepsiburada.MarsRover.Business.Interface
{
    public interface IRoverService
    {
        void TakeAction(InputModel inputModel, Rover currentRover);

        bool IsThereAnyRoverOnThePosition(InputModel inputModel, Rover currentRover);

        void AddRoverPositionHistory(Rover rover);
    }
}

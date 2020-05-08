using Hepsiburada.MarsRover.Entities.Entity;

namespace Hepsiburada.MarsRover.Business.Interface
{
    public interface IRoverCommandService
    {
        void MoveForward(RoverPosition roverPosition);

        void RotateLeft(RoverPosition roverPosition);

        void RotateRight(RoverPosition roverPosition);
    }
}
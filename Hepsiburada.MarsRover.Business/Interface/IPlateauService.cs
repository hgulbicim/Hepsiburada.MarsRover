using Hepsiburada.MarsRover.Entities.Entity;

namespace Hepsiburada.MarsRover.Business.Interface
{
    public interface IPlateauService
    {
        void SetPlateauPosition(Position plateauPosition);

        void IsValidPositionOnThePlateau(Position position);

        bool IsNextPositionInBounds(Position position, RoverPosition nextPosition);

        void IsValidRoverPositionOnThePlateau(RoverPosition roverPosition);
    }
}
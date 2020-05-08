using Hepsiburada.MarsRover.Business.Enum.Exception;
using Hepsiburada.MarsRover.Business.Interface;
using Hepsiburada.MarsRover.Core.CustomException;
using Hepsiburada.MarsRover.Entities.Entity;

namespace Hepsiburada.MarsRover.Business.OperationService
{
    public class PlateauService : IPlateauService
    {
        private Position _plateauPosition { get; set; }

        public void SetPlateauPosition(Position plateauPosition)
        {
            _plateauPosition = plateauPosition;
        }

        public void IsValidPositionOnThePlateau(Position position)
        {
            if (position == null || position.X <= 1 || position.Y <= 1)
            {
                throw new BusinessException(BusinessExceptionCode.InvalidPlateauPosition.GetHashCode());
            }
        }

        public bool IsNextPositionInBounds(Position position, RoverPosition nextPosition)
        {
            return (nextPosition.X < 0 || nextPosition.Y < 0 || position.X < nextPosition.X || position.Y < nextPosition.Y);
        }

        public void IsValidRoverPositionOnThePlateau(RoverPosition roverPosition)
        {
            if (roverPosition.X > _plateauPosition.X || roverPosition.Y > _plateauPosition.Y)
            {
                throw new BusinessException(BusinessExceptionCode.InvalidRoverPositionOnThePlateau.GetHashCode());
            }
        }
    }
}

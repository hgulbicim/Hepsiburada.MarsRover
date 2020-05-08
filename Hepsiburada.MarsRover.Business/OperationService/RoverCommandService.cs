using Hepsiburada.MarsRover.Business.Enum;
using Hepsiburada.MarsRover.Business.Enum.Exception;
using Hepsiburada.MarsRover.Business.Interface;
using Hepsiburada.MarsRover.Core.CustomException;
using Hepsiburada.MarsRover.Entities.Entity;

namespace Hepsiburada.MarsRover.Business.OperationService
{
    public class RoverCommandService : IRoverCommandService
    {
        public void MoveForward(RoverPosition roverPosition)
        {
            switch (roverPosition.CurrentDirectionType)
            {
                case DirectionType.North:
                    roverPosition.Y += 1;
                    break;
                case DirectionType.South:
                    roverPosition.Y -= 1;
                    break;
                case DirectionType.East:
                    roverPosition.X += 1;
                    break;
                case DirectionType.West:
                    roverPosition.X -= 1;
                    break;
                default:
                    throw new BusinessException(BusinessExceptionCode.InvalidDirectionType.GetHashCode());
            }
        }

        public void RotateLeft(RoverPosition roverPosition)
        {
            switch (roverPosition.CurrentDirectionType)
            {
                case DirectionType.North:
                    roverPosition.CurrentDirectionType = DirectionType.West;
                    break;
                case DirectionType.South:
                    roverPosition.CurrentDirectionType = DirectionType.East;
                    break;
                case DirectionType.East:
                    roverPosition.CurrentDirectionType = DirectionType.North;
                    break;
                case DirectionType.West:
                    roverPosition.CurrentDirectionType = DirectionType.South;
                    break;
                default:
                    throw new BusinessException(BusinessExceptionCode.InvalidDirectionType.GetHashCode());
            }
        }

        public void RotateRight(RoverPosition roverPosition)
        {
            switch (roverPosition.CurrentDirectionType)
            {
                case DirectionType.North:
                    roverPosition.CurrentDirectionType = DirectionType.East;
                    break;
                case DirectionType.South:
                    roverPosition.CurrentDirectionType = DirectionType.West;
                    break;
                case DirectionType.East:
                    roverPosition.CurrentDirectionType = DirectionType.South;
                    break;
                case DirectionType.West:
                    roverPosition.CurrentDirectionType = DirectionType.North;
                    break;
                default:
                    throw new BusinessException(BusinessExceptionCode.InvalidDirectionType.GetHashCode());
            }
        }
    }
}

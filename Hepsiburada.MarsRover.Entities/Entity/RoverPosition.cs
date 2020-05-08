using Hepsiburada.MarsRover.Business.Enum;
using Hepsiburada.MarsRover.Business.Enum.Exception;
using Hepsiburada.MarsRover.Core.CustomException;
using System.ComponentModel.DataAnnotations;

namespace Hepsiburada.MarsRover.Entities.Entity
{
    public class RoverPosition : Position
    {
        [Display(Name = "Direction")]
        public DirectionType CurrentDirectionType { get; set; }

        public override string ToString()
        {
            return $"{X} {Y} {MapCurrentDirectionType(CurrentDirectionType)}";
        }

        private string MapCurrentDirectionType(DirectionType directionType)
        {
            switch (directionType)
            {
                case DirectionType.North:
                    return "N";
                case DirectionType.South:
                    return "S";
                case DirectionType.East:
                    return "E";
                case DirectionType.West:
                    return "W";
                default:
                    throw new BusinessException(BusinessExceptionCode.InvalidDirectionType.GetHashCode());
            }
        }
    }
}

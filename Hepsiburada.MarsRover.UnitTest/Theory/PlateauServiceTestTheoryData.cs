using Hepsiburada.MarsRover.Business.Enum;
using Hepsiburada.MarsRover.Entities.Entity;
using Hepsiburada.MarsRover.UnitTest.Poco;
using System.Collections.Generic;
using Xunit;

namespace Hepsiburada.MarsRover.UnitTest.Theory
{
    public class PlateauServiceTestTheoryData : TheoryData<PlateauServiceTestParameter>
    {
        public PlateauServiceTestTheoryData()
        {
            Add(new PlateauServiceTestParameter
            {
                Actual = new Position { X = 5, Y = 5 },
                RoverPosition = new RoverPosition { CurrentDirectionType = DirectionType.East, X = 1, Y = 3 },
                Expected = true
            });

            Add(new PlateauServiceTestParameter
            {
                Actual = new Position { X = 5, Y = 5 },
                RoverPosition = new RoverPosition { CurrentDirectionType = DirectionType.East, X = 1, Y = 3 },
                Expected = true
            });
        }

        public static IEnumerable<object[]> IsValidRoverPositionOnThePlateau
        {
            get
            {
                yield return new object[] { new RoverPosition { CurrentDirectionType = DirectionType.North, X = 5, Y = 3 }, true };
                yield return new object[] { new RoverPosition { CurrentDirectionType = DirectionType.West, X = 2, Y = 4 }, true };
                yield return new object[] { new RoverPosition { CurrentDirectionType = DirectionType.South, X = 1, Y = 7 }, false };
                yield return new object[] { new RoverPosition { CurrentDirectionType = DirectionType.East, X = 10, Y = 3 }, false };
            }
        }

        public static IEnumerable<object[]> IsValidPositionOnThePlateau
        {
            get
            {
                yield return new object[] { null, false };
                yield return new object[] { new Position { X = 2, Y = 4 }, true };
                yield return new object[] { new Position { X = -9, Y = 7 }, false };
                yield return new object[] { new Position { X = 4, Y = 3 }, true };
            }
        }
    }
}
using Hepsiburada.MarsRover.Business.Enum;
using Hepsiburada.MarsRover.Entities.Entity;
using Hepsiburada.MarsRover.UnitTest.Poco;
using System.Collections.Generic;
using Xunit;

namespace Hepsiburada.MarsRover.UnitTest.Theory
{
    public class RoverControllerTestTheoryData : TheoryData<RoverControllerTestParameter>
    {
        public RoverControllerTestTheoryData()
        {
            Add(new RoverControllerTestParameter
            {
                Actual = new InputModel
                {
                    Plateau = new Plateau { PlateauPosition = new Position { X = 5, Y = 5 } },
                    RoverList = new List<Rover> {
                        new Rover {
                            CommandParameters = "LMLMLMLMM",
                            RoverPosition = new RoverPosition{
                                X = 1,
                                Y = 2,
                                CurrentDirectionType = DirectionType.North,
                            }
                        }
                    }
                },
                Expected = new InputModel
                {
                    RoverList = new List<Rover> {
                        new Rover {
                            RoverPosition = new RoverPosition{
                                X = 1,
                                Y = 3,
                                CurrentDirectionType = DirectionType.North
                            }
                        }
                    }
                }
            });

            Add(new RoverControllerTestParameter
            {
                Actual = new InputModel
                {
                    Plateau = new Plateau { PlateauPosition = new Position { X = 5, Y = 5 } },
                    RoverList = new List<Rover> {
                        new Rover {
                            CommandParameters = "MMRMMRMRRM",
                            RoverPosition = new RoverPosition{
                                X = 3,
                                Y = 3,
                                CurrentDirectionType = DirectionType.East
                            }
                        }
                    }
                },
                Expected = new InputModel
                {
                    RoverList = new List<Rover> {
                        new Rover {
                            RoverPosition = new RoverPosition{
                                X = 5,
                                Y = 1,
                                CurrentDirectionType = DirectionType.East
                            }
                        }
                    }
                }
            });
        }
    }
}
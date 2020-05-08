using Hepsiburada.MarsRover.Business.Enum;
using Hepsiburada.MarsRover.Business.Enum.Exception;
using Hepsiburada.MarsRover.Business.Interface;
using Hepsiburada.MarsRover.Core.CustomException;
using Hepsiburada.MarsRover.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hepsiburada.MarsRover.Business.OperationService
{
    public class RoverService : IRoverService
    {
        private readonly IRoverCommandService _roverCommandService;
        private readonly IPlateauService _plateauService;

        public RoverService(IRoverCommandService roverCommandService,
                            IPlateauService plateauService)
        {
            _roverCommandService = roverCommandService;
            _plateauService = plateauService;
        }

        public void TakeAction(InputModel inputModel, Rover currentRover)
        {
            char[] roverCommand = RemoveWhitespace(currentRover.CommandParameters).ToCharArray();

            foreach (var command in roverCommand)
            {
                AddRoverPositionHistory(currentRover);

                switch (MapCommandType(command.ToString()))
                {
                    case CommandType.Left:

                        _roverCommandService.RotateLeft(currentRover.RoverPosition);

                        break;

                    case CommandType.Right:

                        _roverCommandService.RotateRight(currentRover.RoverPosition);

                        break;

                    case CommandType.MoveForward:

                        _roverCommandService.MoveForward(currentRover.RoverPosition);

                        if (_plateauService.IsNextPositionInBounds(inputModel.Plateau.PlateauPosition, currentRover.RoverPosition))
                        {
                            currentRover.RoverPosition = currentRover.RoverPositionHistory.Last();
                        }
                        else if (IsThereAnyRoverOnThePosition(inputModel, currentRover))
                        {
                            currentRover.RoverPosition = currentRover.RoverPositionHistory.Last();
                        }

                        break;

                    default:
                        throw new BusinessException(BusinessExceptionCode.InvalidCommand.GetHashCode());
                }
            }
        }

        private CommandType MapCommandType(string command)
        {
            switch (command.ToUpper())
            {
                case "L":
                    return CommandType.Left;
                case "R":
                    return CommandType.Right;
                case "M":
                    return CommandType.MoveForward;
                default:
                    throw new BusinessException(BusinessExceptionCode.InvalidCommandType.GetHashCode());
            }
        }

        public bool IsThereAnyRoverOnThePosition(InputModel inputModel, Rover currentRover)
        {
            return inputModel.RoverList.Any(x => x.RoverGuid != currentRover.RoverGuid &&
                                         x.RoverPosition.X == currentRover.RoverPosition.X &&
                                         x.RoverPosition.Y == currentRover.RoverPosition.Y);
        }

        public void AddRoverPositionHistory(Rover rover)
        {
            if (rover.RoverPositionHistory == null)
            {
                rover.RoverPositionHistory = new List<RoverPosition>();
            }

            rover.RoverPositionHistory.Add(new RoverPosition
            {
                CurrentDirectionType = rover.RoverPosition.CurrentDirectionType,
                X = rover.RoverPosition.X,
                Y = rover.RoverPosition.Y
            });
        }

        private string RemoveWhitespace(string text)
        {
            return string.Join("", text.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));
        }
    }
}
using Hepsiburada.MarsRover.Business.Interface;
using Hepsiburada.MarsRover.Business.OperationService;
using Hepsiburada.MarsRover.Entities.Entity;
using Hepsiburada.MarsRover.UnitTest.Poco;
using Hepsiburada.MarsRover.UnitTest.Theory;
using Moq;
using System.Linq;
using Xunit;

namespace Hepsiburada.MarsRover.UnitTest
{
    public class RoverServiceFixture
    {
        private Mock<IPlateauService> _plateauServiceMock;
        private IRoverCommandService _roverCommandService;
        private IRoverService _roverService;
        public Position _plateauPosition;

        public RoverServiceFixture()
        {
            _plateauServiceMock = new Mock<IPlateauService>();
            _roverCommandService = new RoverCommandService();
            _roverService = new RoverService(_roverCommandService, _plateauServiceMock.Object);

            _plateauPosition = new Position { X = 5, Y = 5 };

            _plateauServiceMock.Setup(x => x.SetPlateauPosition(_plateauPosition));
        }

        [Theory, ClassData(typeof(RoverServiceTestTheoryData))]
        public void TakeAction_Should_Return_As_Expected(RoverServiceTestParameter parameter)
        {
            _roverService.TakeAction(parameter.InputModel, parameter.InputModel.RoverList.FirstOrDefault());

            Assert.Equal(parameter.Expected.ToString(), parameter.InputModel.RoverList.FirstOrDefault().RoverPosition.ToString());
        }

        [Theory, MemberData(nameof(RoverServiceTestTheoryData.IsThereAnyRoverOnThePosition), MemberType = typeof(RoverServiceTestTheoryData))]
        public void IsThereAnyRoverOnThePosition_Should_Return_As_Expected(InputModel inputModel, bool expected)
        {
            var result = _roverService.IsThereAnyRoverOnThePosition(inputModel, inputModel.RoverList.FirstOrDefault());

            Assert.Equal(expected, result);
        }
    }
}
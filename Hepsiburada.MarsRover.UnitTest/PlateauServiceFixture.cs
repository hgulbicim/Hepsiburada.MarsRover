using Hepsiburada.MarsRover.Business.Interface;
using Hepsiburada.MarsRover.Business.OperationService;
using Hepsiburada.MarsRover.Core.CustomException;
using Hepsiburada.MarsRover.Entities.Entity;
using Hepsiburada.MarsRover.UnitTest.Poco;
using Hepsiburada.MarsRover.UnitTest.Theory;
using Moq;
using Xunit;

namespace Hepsiburada.MarsRover.UnitTest
{
    public class PlateauServiceFixture
    {
        private Mock<IPlateauService> _plateauServiceMock;
        private IPlateauService _plateauService;
        public Position _plateauPosition;

        public PlateauServiceFixture()
        {
            _plateauServiceMock = new Mock<IPlateauService>();
            _plateauService = new PlateauService();

            _plateauPosition = new Position { X = 5, Y = 5 };

            _plateauService.SetPlateauPosition(_plateauPosition);
        }

        [Theory, ClassData(typeof(PlateauServiceTestTheoryData))]
        public void IsNextPositionInBounds_Should_Return_True(PlateauServiceTestParameter parameter)
        {
            //Setup
            _plateauServiceMock.Setup(x => x.IsNextPositionInBounds(parameter.Actual, parameter.RoverPosition)).Returns(true);

            //Act
            var result = _plateauServiceMock.Object.IsNextPositionInBounds(parameter.Actual, parameter.RoverPosition);

            //Assert
            var expected = parameter.Expected;

            Assert.Equal(expected, result);
        }

        [Theory, MemberData(nameof(PlateauServiceTestTheoryData.IsValidRoverPositionOnThePlateau), MemberType = typeof(PlateauServiceTestTheoryData))]
        public void IsNextPositionInBounds_Should_Return_As_Expected(RoverPosition roverPosition, bool expected)
        {
            if (expected)
            {
                _plateauService.IsValidRoverPositionOnThePlateau(roverPosition);
                Assert.True(expected);
            }
            else
            {
                Assert.Throws<BusinessException>(() => _plateauService.IsValidRoverPositionOnThePlateau(roverPosition));
            }
        }

        [Theory, MemberData(nameof(PlateauServiceTestTheoryData.IsValidPositionOnThePlateau), MemberType = typeof(PlateauServiceTestTheoryData))]
        public void IsValidPositionOnThePlateau_Should_Return_As_Expected(Position position, bool expected)
        {
            if (expected)
            {
                _plateauService.IsValidPositionOnThePlateau(position);
                Assert.True(expected);
            }
            else
            {
                Assert.Throws<BusinessException>(() => _plateauService.IsValidPositionOnThePlateau(position));
            }
        }
    }
}

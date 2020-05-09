using Hepsiburada.MarsRover.Business.Assembler;
using Hepsiburada.MarsRover.Business.Interface;
using Hepsiburada.MarsRover.WebUI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Hepsiburada.MarsRover.UnitTest
{
    public class RoverControllerFixture
    {
        private Mock<IRoverService> _roverServiceMock;
        private Mock<IInputProviderService> _inputProviderService;
        private Mock<IInputModelAssembler> _inputModelAssembler;
        private Mock<IPlateauService> _plateauService;

        public RoverControllerFixture()
        {
            _roverServiceMock = new Mock<IRoverService>();
            _inputProviderService = new Mock<IInputProviderService>();
            _inputModelAssembler = new Mock<IInputModelAssembler>();
            _plateauService = new Mock<IPlateauService>();
        }

        [Fact]
        public void Input_ActionExecutes_ReturnsViewForInput()
        {
            //Inject
            var roverController = new RoverController(_inputProviderService.Object, _inputModelAssembler.Object, _plateauService.Object, _roverServiceMock.Object);

            //Act
            var result = roverController.Input();

            //Assert
            Assert.IsType<ViewResult>(result);
        }
    }
}
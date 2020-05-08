using Hepsiburada.MarsRover.Business.Assembler;
using Hepsiburada.MarsRover.Business.Interface;
using Hepsiburada.MarsRover.Entities.Entity;
using Hepsiburada.MarsRover.UnitTest.PoCo;
using Hepsiburada.MarsRover.UnitTest.Theory;
using Hepsiburada.MarsRover.WebUI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Linq;
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

        [Theory, ClassData(typeof(RoverControllerTestTheoryData))]
        public void RoverPosition_Should_Return_As_Expected(RoverControllerTestParameter parameter)
        {
            //Setup
            _roverServiceMock.Setup(x => x.TakeAction(parameter.Actual, parameter.Actual.RoverList.FirstOrDefault()));

            //Inject
            var roverController = new RoverController(_inputProviderService.Object, _inputModelAssembler.Object, _plateauService.Object, _roverServiceMock.Object);

            //Act
            var result = roverController.Input(parameter.Actual);

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);

            var model = Assert.IsAssignableFrom<InputModel>(viewResult.ViewData.Model);

            var expected = parameter.Expected;

            Assert.Equal(expected.RoverList.FirstOrDefault().RoverPosition.ToString(), model.RoverList.FirstOrDefault().RoverPosition.ToString());
        }
    }
}

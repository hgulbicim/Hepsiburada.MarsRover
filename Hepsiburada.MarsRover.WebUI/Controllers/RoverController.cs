using Hepsiburada.MarsRover.Business.Assembler;
using Hepsiburada.MarsRover.Business.Interface;
using Hepsiburada.MarsRover.Entities.Entity;
using Hepsiburada.MarsRover.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;

namespace Hepsiburada.MarsRover.WebUI.Controllers
{
    public class RoverController : BaseController
    {
        private readonly IInputProviderService _inputProviderService;
        private readonly IInputModelAssembler _inputModelAssembler;
        private readonly IPlateauService _plateauService;
        private readonly IRoverService _roverService;

        public RoverController(IInputProviderService inputProviderService,
                               IInputModelAssembler inputModelAssembler,
                               IPlateauService plateauService,
                               IRoverService roverService)
        {
            _inputProviderService = inputProviderService;
            _inputModelAssembler = inputModelAssembler;
            _plateauService = plateauService;
            _roverService = roverService;
        }

        public IActionResult Input()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Input(InputModel inputModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _plateauService.IsValidPositionOnThePlateau(inputModel.Plateau.PlateauPosition);

                    _plateauService.SetPlateauPosition(inputModel.Plateau.PlateauPosition);

                    foreach (var rover in inputModel.RoverList)
                    {
                        _plateauService.IsValidRoverPositionOnThePlateau(rover.RoverPosition);

                        _roverService.TakeAction(inputModel, rover);
                    }
                }
            }
            catch (Exception ex)
            {
                ConfigureMeaningfulErrorMessage(ex);
            }

            return View(inputModel);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult InputValues()
        {
            InputModel inputModel = new InputModel();

            try
            {
                string inputValues = _inputProviderService.GetInputValues();

                inputModel = _inputModelAssembler.InputModel(inputValues);

                _plateauService.IsValidPositionOnThePlateau(inputModel.Plateau.PlateauPosition);

                foreach (var rover in inputModel.RoverList)
                {
                    _roverService.TakeAction(inputModel, rover);
                }
            }
            catch (Exception ex)
            {
                ConfigureMeaningfulErrorMessage(ex);
            }

            return View("Input", inputModel);
        }

        public ActionResult RoverContent(int index)
        {
            return PartialView("_RoverTemplate", new InputModel());
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

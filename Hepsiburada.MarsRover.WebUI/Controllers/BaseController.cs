using Hepsiburada.MarsRover.Core.CustomException;
using Hepsiburada.MarsRover.GlobalResources;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Resources;

namespace Hepsiburada.MarsRover.WebUI.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {
            
        }

        public void ConfigureMeaningfulErrorMessage(Exception exception)
        {
            if (exception is BusinessException)
                ModelState.AddModelError(string.Empty, GetExceptionMessageFromResource(exception.Message));
            else
                ModelState.AddModelError(string.Empty, exception.Message);

            ViewBag.HasError = true;
        }

        private string GetExceptionMessageFromResource(string errorCode)
        {
            ResourceManager resourceManager = new ResourceManager(typeof(ExceptionMessage));
            var responseMessage = resourceManager.GetString(string.Format("EX{0}", errorCode));
            return responseMessage ?? errorCode;
        }
    }
}
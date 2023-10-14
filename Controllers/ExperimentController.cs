using ABP_test.Interfaces.Services;
using ABP_test.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ABP_test.Controllers
{
    public class ExperimentController : Controller
    {
        private readonly IExperimentService _experimentService;

        public ExperimentController(IExperimentService experimentService)
        {
            _experimentService = experimentService;
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult CreateExperiment(string key)
        {
            if (key == null)
            {
                throw new Exception("Key is null");
            }

            _experimentService.CreateExperiment(key);
            return Ok();
        }
    }

}
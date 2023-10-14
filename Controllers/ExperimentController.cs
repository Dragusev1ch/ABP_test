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

        [HttpGet("button-color")]
        public ActionResult<Experiment> GetButtonColorExperiment(string deviceToken)
        {
            var experimentResult = _experimentService.GetButtonColorExperiment(deviceToken);
            if (experimentResult == null)
            {
                return NotFound();
            }

            return Ok(experimentResult);
        }

        [HttpGet("price")]
        public ActionResult<Experiment> GetPriceExperiment(string deviceToken)
        {
            var experimentResult = _experimentService.GetPriceExperiment(deviceToken);
            if (experimentResult == null)
            {
                return NotFound();
            }

            return Ok(experimentResult);
        }
    }

}
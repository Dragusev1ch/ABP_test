using ABP_test.Interfaces.Services;
using ABP_test.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ABP_test.Controllers
{
    public class ExperimentController : Controller
    {
        private readonly IExperimentService _experimentService;

        // Constructor to inject the experiment service
        public ExperimentController(IExperimentService experimentService)
        {
            _experimentService = experimentService;
        }

        // Get the button color experiment for a specific device
        [HttpGet("button-color")]
        public ActionResult<Experiment> GetButtonColorExperiment(string deviceToken)
        {
            // Call the experiment service to get the button color experiment
            var experimentResult = _experimentService.GetButtonColorExperiment(deviceToken);

            // If the experiment result is null, return a 'Not Found' response
            if (experimentResult == null)
            {
                return NotFound();
            }

            // Return the experiment result if it's found
            return Ok(experimentResult);
        }

        // Get the price experiment for a specific device
        [HttpGet("price")]
        public ActionResult<Experiment> GetPriceExperiment(string deviceToken)
        {
            // Call the experiment service to get the price experiment
            var experimentResult = _experimentService.GetPriceExperiment(deviceToken);

            // If the experiment result is null, return a 'Not Found' response
            if (experimentResult == null)
            {
                return NotFound();
            }

            // Return the experiment result if it's found
            return Ok(experimentResult);
        }

        // Get a list of all experiments
        [HttpGet("experiments")]
        public IActionResult GetExperimentsList()
        {
            // Call the experiment service to get a list of all experiments
            return Ok(_experimentService.GetAllExperiments());
        }
    }
}

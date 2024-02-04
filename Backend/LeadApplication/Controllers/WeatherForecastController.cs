using LeadApplication.Domain.Interfaces.Services;
using LeadApplication.Domain.Query.ListTeste;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LeadApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ILeadServices _leadServices;
        private readonly IMediator _mediator;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ILeadServices leadServices, IMediator mediator)
        {
            _logger = logger;
            _leadServices = leadServices;
            _mediator = mediator;
        }

        //[HttpGet(Name = "GetWeatherForecast")]
        //public IActionResult Get()
        //{
        //    return Ok(_leadServices.Test());
        //}

        [HttpGet(Name = "teste")]
        public ActionResult<string> teste([FromQuery]ListTesteQuery query)
        {
            var response = _mediator.Send(query);

            if(response is null)
            {
                return NotFound();
            }

            return Ok(response);
        }
    }
}

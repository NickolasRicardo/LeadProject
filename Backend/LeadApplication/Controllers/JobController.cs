using LeadApplication.Domain.Interfaces.Services;
using LeadApplication.Domain.Query.ListTeste;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LeadApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JobController : ControllerBase
    {
        private readonly ILogger<JobController> _logger;
        private readonly IMediator _mediator;

        public JobController(ILogger<JobController> logger,  IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

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

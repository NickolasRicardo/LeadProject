using LeadApplication.Domain.Commands.CreateTeste;
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

        public JobController(ILogger<JobController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<ListJobsQueryResponse>> Get([FromQuery] ListJobsQuery query)
        {
            try
            {
                var response = await _mediator.Send(query);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateJob")]
        public IActionResult UpdateJob([FromBody] UpdateJobCommand command)
        {
            try
            {
                var response = _mediator.Send(command).Result;

                if (!response)
                {
                    return NotFound();
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}

using System.Threading.Tasks;
using BlueSquare.Jobs.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using BlueSquare.Domain.Dtos;
using BlueSquare.Jobs.Application.Commands;

namespace BlueSquare.Jobs.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class JobController : ControllerBase
    {
        private readonly IMediator _mediator;

        public JobController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> GetJobs()
        {
            var jobDtos = await _mediator.Send(new GetAllJobsQuery());
            var jobsJson = JsonSerializer.Serialize(jobDtos);

            return Ok(jobsJson);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetJobsById(int id)
        {
            var jobDto = await _mediator.Send(new GetJobByIdQuery { Id = id });

            if (jobDto is null)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpPost("/Create")]
        public async Task<ActionResult> CreateJob(JobDto jobDto)
        {
            await _mediator.Send(new CreateJobCommand { JobDto = jobDto });
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> UpdateJob(JobDto jobDto)
        {
            var updatedJobDto = await _mediator.Send(new UpdateJobCommand { JobDto = jobDto });

            if (updatedJobDto is null)
            {
                return NotFound();
            }

            var updatedJobJson = JsonSerializer.Serialize(updatedJobDto);

            return Ok(updatedJobJson);
        }
    }
}

using System.Threading;
using System.Threading.Tasks;
using BlueSquare.Domain.Dtos;
using BlueSquare.Domain.Entities;
using BlueSquare.Domain.Enums;
using BlueSquare.Jobs.Application.Commands;
using BlueSquare.Jobs.Application.Repositories;
using MediatR;

namespace BlueSquare.Jobs.Application.Handlers
{
    public class UpdateJobCommandHandler : IRequestHandler<UpdateJobCommand, JobDto>
    {
        private readonly IJobRepository _jobRepository;

        public UpdateJobCommandHandler(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public Task<JobDto> Handle(UpdateJobCommand request, CancellationToken cancellationToken)
        {
            var jobDto = request.JobDto;
            var job = new Job
            {
                Date = jobDto.Date,
                Type = jobDto.Type,
                Status = jobDto.Status,
                Customer = jobDto.Customer,
                Product = jobDto.Product,
                Updates = jobDto.Updates
            };

            var updatedJob = _jobRepository.Update(job);
            var updatedJobDto = new JobDto()
            {
                Date = updatedJob.Date,
                Type = updatedJob.Type,
                Status = updatedJob.Status,
                Customer = updatedJob.Customer,
                Product = updatedJob.Product,
                Updates = updatedJob.Updates
            };

            if (updatedJobDto.Status == JobStatus.Closed)
            {
                // Alert user by SMS
            }

            return Task.FromResult(updatedJobDto);
        }
    }
}

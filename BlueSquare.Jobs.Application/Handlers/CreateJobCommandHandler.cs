using System.Threading;
using System.Threading.Tasks;
using BlueSquare.Domain.Entities;
using BlueSquare.Jobs.Application.Commands;
using BlueSquare.Jobs.Application.Repositories;
using MediatR;

namespace BlueSquare.Jobs.Application.Handlers
{
    public class CreateJobCommandHandler : IRequestHandler<CreateJobCommand, bool>
    {
        private readonly IJobRepository _jobRepository;

        public CreateJobCommandHandler(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public Task<bool> Handle(CreateJobCommand request, CancellationToken cancellationToken)
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
            _jobRepository.Create(job);

            return Task.FromResult(true);
        }
    }
}

using BlueSquare.Domain.Dtos;
using BlueSquare.Jobs.Application.Queries;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using BlueSquare.Jobs.Application.Repositories;

namespace BlueSquare.Jobs.Application.Handlers
{
    public class GetJobByIdQueryHandler : IRequestHandler<GetJobByIdQuery, JobDto>
    {
        private readonly IJobRepository _jobRepository;

        public GetJobByIdQueryHandler(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public async Task<JobDto> Handle(GetJobByIdQuery request, CancellationToken cancellationToken)
        {
            var job = await _jobRepository.Get(request.Id.ToString());

            if (job is null)
            {
                return null;
            }

            return new JobDto
            {
                Date = job.Date,
                Type = job.Type,
                Status = job.Status,
                Customer = job.Customer,
                Product = job.Product,
                Updates = job.Updates
            };
        }
    }
}

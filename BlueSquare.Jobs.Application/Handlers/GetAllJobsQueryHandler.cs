using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BlueSquare.Domain.Dtos;
using BlueSquare.Jobs.Application.Queries;
using BlueSquare.Jobs.Application.Repositories;
using MediatR;

namespace BlueSquare.Jobs.Application.Handlers
{
    public class GetAllJobsQueryHandler : IRequestHandler<GetAllJobsQuery, IEnumerable<JobDto>>
    {
        private readonly IJobRepository _jobRepository;

        public GetAllJobsQueryHandler(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public async Task<IEnumerable<JobDto>> Handle(GetAllJobsQuery request, CancellationToken cancellationToken)
        {
            var jobs = await _jobRepository.GetAll();

            var jobDtos = new List<JobDto>();
            foreach (var job in jobs)
            {
                jobDtos.Add(new JobDto
                {
                    Date = job.Date,
                    Type = job.Type,
                    Status = job.Status,
                    Customer = job.Customer,
                    Product = job.Product,
                    Updates = job.Updates
                });
            }

            return jobDtos;
        }
    }
}

using System.Collections.Generic;
using BlueSquare.Domain.Dtos;
using MediatR;

namespace BlueSquare.Jobs.Application.Queries
{
    public class GetAllJobsQuery : IRequest<IEnumerable<JobDto>>
    {
    }
}

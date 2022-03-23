using BlueSquare.Domain.Dtos;
using MediatR;

namespace BlueSquare.Jobs.Application.Commands
{
    public class UpdateJobCommand : IRequest<JobDto>
    {
        public JobDto JobDto { get; set; }
    }
}

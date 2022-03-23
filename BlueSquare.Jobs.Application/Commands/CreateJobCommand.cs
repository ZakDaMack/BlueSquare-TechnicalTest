using BlueSquare.Domain.Dtos;
using MediatR;

namespace BlueSquare.Jobs.Application.Commands
{
    public class CreateJobCommand : IRequest<bool>
    {
        public JobDto JobDto { get; set; }
    }
}

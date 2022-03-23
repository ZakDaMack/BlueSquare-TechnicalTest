using BlueSquare.Domain.Entities;
using BlueSquare.Infrastructure.Repositories;

namespace BlueSquare.Jobs.Application.Repositories
{
    public interface IJobRepository : IBaseRepository<Job>
    {
    }
}

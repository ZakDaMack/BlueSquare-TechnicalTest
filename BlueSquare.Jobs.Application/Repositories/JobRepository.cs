using BlueSquare.Domain.Entities;
using BlueSquare.Infrastructure.Contexts;
using BlueSquare.Infrastructure.Repositories;

namespace BlueSquare.Jobs.Application.Repositories
{
    public class JobRepository : BaseRepository<Job>, IJobRepository
    {
        public JobRepository(IMongoJobDbContext context) : base(context)
        {
        }
    }
}

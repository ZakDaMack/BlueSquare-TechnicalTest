using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlueSquare.Infrastructure.Repositories
{
    public interface IBaseRepository<TEntity>
    {
        TEntity Update(TEntity entity);
        Task<TEntity> Get(string id);
        Task<IEnumerable<TEntity>> GetAll();
        Task Create(TEntity entity);
    }
}

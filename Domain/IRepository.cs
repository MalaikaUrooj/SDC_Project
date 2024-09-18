using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain
{
    public interface IRepository<TEntity>
    {
        Task<TEntity> SearchAsync(int id);
        Task<List<TEntity>> SearchByNameAsync(string name);
        Task DeleteAsync(TEntity entity, int id);
        Task UpdateAsync(TEntity entity, int id);
        Task AddAsync(TEntity entity);
        Task<List<TEntity>> GetAllAsync();
    }
}

using System.Linq.Expressions;
using VL_DataAccess.Models;

namespace Repository_Layer
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task Delete(TEntity entity);
        Task<TEntity> Find(params object[] keys);
        Task<IEnumerable<TEntity>> GetAll(int offset = 0, int limit = 50, Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] joinedEntities);
        Task<TEntity> Insert(TEntity entity);
        Task SaveChanges();
        Task Update(TEntity entity);
    }
}
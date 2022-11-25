using System.Linq.Expressions;
using VL_DataAccess.Models;

namespace Repository_Layer
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task Delete(TEntity entity);
        Task<TEntity> Find(Guid id);
        Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] joinedEntities);
        Task Insert(TEntity entity);
        Task SaveChanges();
        Task Update(TEntity entity);
    }
}
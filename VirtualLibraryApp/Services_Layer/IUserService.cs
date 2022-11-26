using System.Linq.Expressions;
using VL_DataAccess.Models;

namespace Services_Layer
{
    public interface IUserService
    {
        Task Delete(Guid id);
        Task<User> Get(Guid id);
        Task<IEnumerable<User>> GetAll(Expression<Func<User, bool>> filter = null, params Expression<Func<User, object>>[] joinedEntities);
        Task Insert(User user);
        Task Update(User user);
    }
}
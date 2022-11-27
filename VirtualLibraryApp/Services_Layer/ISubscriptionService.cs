using System.Linq.Expressions;
using VL_DataAccess.Models;

namespace Services_Layer
{
    public interface ISubscriptionService
    {
        Task Delete(Guid UserId, Guid Authorid);
        Task<Subscription> Get(Guid id);
        //Task<IEnumerable<Subscription>> GetAll(int offset = 0, int limit = 50, Expression<Func<Subscription, bool>> filter = null, params Expression<Func<Subscription, object>>[] joinedEntities);
        Task Insert(Subscription subscription);
        Task Update(Subscription subscription);
    }
}
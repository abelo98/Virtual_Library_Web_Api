using Repository_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VL_DataAccess.Models;

namespace Services_Layer
{
    public class SubscriptionService : ISubscriptionService
    {
        readonly IRepository<Subscription> _repository;
        public SubscriptionService(IRepository<Subscription> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Subscription>> GetAll(Expression<Func<Subscription, bool>> filter = null,
           params Expression<Func<Subscription, object>>[] joinedEntities)
        {
            return await _repository.GetAll(filter, joinedEntities);
        }

        public async Task<Subscription> Get(Guid id) => await _repository.Find(id);

        public async Task Delete(Guid id)
        {
            Subscription subscription = await _repository.Find(id);
            await _repository.Delete(subscription);
        }

        public async Task Update(Subscription subscription)
        {
            await _repository.Update(subscription);
        }

        public async Task Insert(Subscription subscription)
        {
            await _repository.Insert(subscription);
        }
    }
}

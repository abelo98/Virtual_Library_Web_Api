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
    public class UserService : IUserService
    {
        readonly IRepository<User> _repository;
        public UserService(Repository<User> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<User>> GetAll(Expression<Func<User, bool>> filter = null,
           params Expression<Func<User, object>>[] joinedEntities)
        {
            return await _repository.GetAll(filter, joinedEntities);
        }

        public async Task<User> Get(Guid id) => await _repository.Find(id);

        public async Task Delete(Guid id)
        {
            User user = await _repository.Find(id);
            await _repository.Delete(user);
        }

        public async Task Update(User user)
        {
            await _repository.Update(user);
        }

        public async Task Insert(User user)
        {
            await _repository.Insert(user);
        }
    }
}

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
    public class AuthorService : IAuthorService
    {
        readonly Repository<Author> _repository;
        public AuthorService(Repository<Author> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Author>> GetAll(Expression<Func<Author, bool>> filter = null,
           params Expression<Func<Author, object>>[] joinedEntities)
        {
            return await _repository.GetAll(filter, joinedEntities);
        }

        public async Task<Author> Get(Guid id) => await _repository.Find(id);

        public async Task Delete(Guid id)
        {
            Author author = await _repository.Find(id);
            await _repository.Delete(author);
        }

        public async Task Update(Author author)
        {
            await _repository.Update(author);
        }

        public async Task Insert(Author author)
        {
            await _repository.Insert(author);
        }
    }
}

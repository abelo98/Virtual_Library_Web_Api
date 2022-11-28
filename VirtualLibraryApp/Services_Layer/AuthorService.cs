using Microsoft.EntityFrameworkCore;
using Repository_Layer;
using Services_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VL_DataAccess;
using VL_DataAccess.Models;

namespace Services_Layer
{
    public class AuthorService : IAuthorService
    {
        readonly IRepository<Author> _repository;
        readonly VLContext _dbContext;

        public AuthorService(IRepository<Author> repository, VLContext dbContext)
        {
            _repository = repository;
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Author>> GetAll(int offset = 0, int limit = 50, Expression<Func<Author, bool>> filter = null,
           params Expression<Func<Author, object>>[] joinedEntities)
        {
            return await _repository.GetAll(offset, limit, filter, joinedEntities);
        }

        public async Task<AuthorDetailsServiceModel> Get(Guid id)
        {
            IQueryable<Author> queryable = _dbContext.Authors;

            var result = await queryable.Where(x => x.Id == id)
                .Select(a => new AuthorDetailsServiceModel
                {
                    BirthDate = a.BirthDate,
                    Subscribers = a.Users.Count,
                    Name = a.Name,
                    Nationality = a.Nationality,
                    Books = a.Books
                })
                .FirstOrDefaultAsync();

            if (result == null)
                throw new ArgumentNullException("null entity");

            return result;
        }

        public async Task Delete(Guid id)
        {
            Author author = await _repository.Find(id);
            await _repository.Delete(author);
        }

        public async Task Update(Author author)
        {
            await _repository.Update(author);
        }

        public async Task<Author> Insert(Author author)
        {
            return await _repository.Insert(author);
        }
    }
}

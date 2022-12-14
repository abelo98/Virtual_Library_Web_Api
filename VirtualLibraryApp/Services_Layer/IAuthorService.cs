using Services_Layer.Models;
using System.Linq.Expressions;
using VL_DataAccess.Models;

namespace Services_Layer
{
    public interface IAuthorService
    {
        Task Delete(Guid id);
        Task<AuthorDetailsServiceModel> Get(Guid id);
        Task<IEnumerable<Author>> GetAll(int offset = 0, int limit = 50, Expression<Func<Author, bool>> filter = null, params Expression<Func<Author, object>>[] joinedEntities);
        Task<Author> Insert(Author author);
        Task Update(Author author);
    }
}
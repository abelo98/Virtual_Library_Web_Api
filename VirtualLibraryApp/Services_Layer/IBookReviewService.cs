using System.Linq.Expressions;
using VL_DataAccess.Models;

namespace Services_Layer
{
    public interface IBookReviewService
    {
        Task Delete(Guid id);
        Task<BookReview> Get(Guid id);
        Task<IEnumerable<BookReview>> GetAll(Expression<Func<BookReview, bool>> filter = null, params Expression<Func<BookReview, object>>[] joinedEntities);
        Task Insert(BookReview bookReview);
        Task Update(BookReview bookReview);
    }
}
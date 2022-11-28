using Services_Layer.Models;
using System.Linq.Expressions;
using VL_DataAccess.Models;

namespace Services_Layer
{
    public interface IBookReviewService
    {
        Task Delete(Guid id);
        Task<BookReview> Get(Guid id);
        Task<IEnumerable<BookReview>> GetAll(GetAllReviewsFilter filter, string bookId, int offset = 0, int limit = 50);
        Task<BookReview> Insert(string bookId, Guid userId,BookReview bookReview);
        Task Update(BookReview bookReview);
    }
}
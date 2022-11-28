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
    public class BookReviewService : IBookReviewService
    {
        readonly IRepository<BookReview> _repository;
        public BookReviewService(IRepository<BookReview> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<BookReview>> GetAll(int offset = 0, int limit = 50, Expression<Func<BookReview, bool>> filter = null,
           params Expression<Func<BookReview, object>>[] joinedEntities)
        {
            return await _repository.GetAll(offset, limit, filter, joinedEntities);
        }

        public async Task<BookReview> Get(Guid id) => await _repository.Find(id);

        public async Task Delete(Guid id)
        {
            BookReview bookReview = await _repository.Find(id);
            await _repository.Delete(bookReview);
        }

        public async Task Update(BookReview bookReview)
        {
            await _repository.Update(bookReview);
        }

        public async Task<BookReview> Insert(BookReview bookReview)
        {
           return await _repository.Insert(bookReview);
        }
    }
}

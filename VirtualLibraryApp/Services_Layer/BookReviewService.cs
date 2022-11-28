using Microsoft.EntityFrameworkCore;
using Repository_Layer;
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
    public class BookReviewService : IBookReviewService
    {
        readonly IRepository<BookReview> _repository;
        readonly VLContext _dbContext;

        public BookReviewService(IRepository<BookReview> repository, VLContext dbContext)
        {
            _repository = repository;
            _dbContext = dbContext;
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

        public async Task<BookReview> Insert(string bookId,Guid userId,BookReview bookReview)
        {
            bookReview.LibraryUserId = userId;
            bookReview.BookId = bookId;


            var book = await _dbContext.Books
                .Where(x => x.ISBN == bookId)
                .Select(x => new { foundBook = x, totalReviews = x.BookReviews.Count })
                .FirstOrDefaultAsync();
            if (book == null)
                throw new ArgumentNullException("Book dosen't exist");

            Book updatedBook = book.foundBook;
            updatedBook.AverageRate += ((int)bookReview.Rate - updatedBook.AverageRate) / (book.totalReviews + 1);

            _dbContext.Books.Update(updatedBook);
            var result = await _dbContext.BookReviews.AddAsync(bookReview);

            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

    }
}

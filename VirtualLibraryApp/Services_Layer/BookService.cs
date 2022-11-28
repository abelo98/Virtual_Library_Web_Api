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
    public class BookService : IBookService
    {
        readonly IRepository<Book> _repository;
        readonly VLContext _context;
        public BookService(IRepository<Book> repository,VLContext context)
        {
            _repository = repository;
            _context=context;
        }

        public async Task<IEnumerable<Book>> GetAll(int offset = 0, int limit = 50, Expression<Func<Book, bool>> filter = null,
           params Expression<Func<Book, object>>[] joinedEntities)
        {
            return await _repository.GetAll(offset, limit, filter, joinedEntities);
        }

        public async Task<Book> Get(Guid id) => await _repository.Find(id);

        public async Task Delete(Guid id)
        {
            Book book = await _repository.Find(id);
            await _repository.Delete(book);
        }

        public async Task Update(Book book)
        {
            await _repository.Update(book);
        }

        public async Task<Book> Insert(Guid authorId,Book book)
        {
            book.AuthorId = authorId;
            var result = _context.Books.Add(book).Entity;
            await _context.SaveChangesAsync();
            return result;
        }
    }
}

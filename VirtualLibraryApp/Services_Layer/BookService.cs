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
    public class BookService : IBookService
    {
        readonly IRepository<Book> _repository;
        public BookService(IRepository<Book> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Book>> GetAll(Expression<Func<Book, bool>> filter = null,
           params Expression<Func<Book, object>>[] joinedEntities)
        {
            return await _repository.GetAll(filter, joinedEntities);
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

        public async Task Insert(Book book)
        {
            await _repository.Insert(book);
        }
    }
}

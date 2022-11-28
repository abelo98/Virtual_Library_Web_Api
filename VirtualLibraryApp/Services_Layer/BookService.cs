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
    public class BookService : IBookService
    {
        readonly IRepository<Book> _repository;
        readonly VLContext _dbContext;
        public BookService(IRepository<Book> repository,VLContext dbContext)
        {
            _repository = repository;
            _dbContext= dbContext;
        }

        public async Task<IEnumerable<Book>> GetAll(GetAllBooksFilter filter,int offset = 0, int limit = 50)
        {
            IQueryable<Book> queriable = _dbContext.Books;
            queriable = AddsFiltersOnQuery(queriable, filter);

            return await queriable
                .Skip(offset)
                .Take(limit)
                .ToListAsync();

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

        private static IQueryable<Book> AddsFiltersOnQuery(IQueryable<Book> queriable, GetAllBooksFilter filter)
        {
            if (filter?.AuthorId != null)
            {
                queriable = queriable.Where(x => x.AuthorId==filter.AuthorId);
            }

            if (!string.IsNullOrEmpty(filter?.EditorialName))
            {
                queriable = queriable.Where(x => x.EditorialName == filter.EditorialName);
            }
            if (filter?.Before != null )
            {
                queriable = queriable.Where(x => x.PublishingDate < filter.Before);
            }

            if (filter?.After != null)
            {
                queriable = queriable.Where(x => x.PublishingDate < filter.After);
            }

            if (filter?.Sort != null)
            {
                if (filter.Sort.HasValue)
                { queriable = queriable.OrderBy(x => x.Rate); }
                else { queriable = queriable.OrderByDescending(x => x.Rate); }
            }

            return queriable;
        }
    }
}

﻿using Microsoft.EntityFrameworkCore;
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
        readonly VLContext _dbContext;
        public BookService(VLContext dbContext)
        {

            _dbContext= dbContext;
        }

        public async Task<IEnumerable<BookServiceModel>> GetAll(GetAllBooksFilter filter,int offset = 0, int limit = 50)
        {
            IQueryable<Book> queriable = _dbContext.Books;
            queriable = AddsFiltersOnQuery(queriable, filter);

            return await queriable
                .Skip(offset)
                .Take(limit)
                .Include(b => b.Author)
                .Select(b => new BookServiceModel { 
                    AuthorName = b.Author.Name, 
                    EditorialName = b.EditorialName,
                    ISBN = b.ISBN,
                    Title = b.Title})
                .ToListAsync();
        }


        public async Task<Book> Get(Guid id) => throw new NotImplementedException();


        public async Task Delete(Guid id)
        {
            throw new NotImplementedException();

        }

        public async Task Update(Book book)
        {
            throw new NotImplementedException();
        }

        public async Task<Book> Insert(Guid authorId,Book book)
        {
            book.AuthorId = authorId;
            var result = _dbContext.Books.Add(book).Entity;
            await _dbContext.SaveChangesAsync();
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
                { queriable = queriable.OrderBy(x => x.AverageRate); }
                else { queriable = queriable.OrderByDescending(x => x.AverageRate); }
            }

            return queriable;
        }
    }
}

﻿using System.Linq.Expressions;
using VL_DataAccess.Models;

namespace Services_Layer
{
    public interface IBookService
    {
        Task Delete(Guid id);
        Task<Book> Get(Guid id);
        Task<IEnumerable<Book>> GetAll(Expression<Func<Book, bool>> filter = null, params Expression<Func<Book, object>>[] joinedEntities);
        Task Insert(Book book);
        Task Update(Book book);
    }
}
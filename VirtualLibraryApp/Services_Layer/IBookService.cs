using Services_Layer.Models;
using System.Linq.Expressions;
using VL_DataAccess.Models;

namespace Services_Layer
{
    public interface IBookService
    {
        Task Delete(Guid id);
        Task<Book> Get(Guid id);
        Task<IEnumerable<BookServiceModel>> GetAll(GetAllBooksFilter filter, int offset = 0, int limit = 50);
        Task<Book> Insert(Guid authorId,Book book);
        Task Update(Book book);
    }
}
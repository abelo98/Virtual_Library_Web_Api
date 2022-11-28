using Microsoft.AspNetCore.JsonPatch;
using Services_Layer.Models;
using System.Linq.Expressions;
using VL_DataAccess.Models;

namespace Services_Layer
{
    public interface ILibraryUserService
    {
        Task Delete(Guid id);
        Task<LibraryUser> Get(Guid id);
        Task<AllUsers> GetAll(int offset = 0, int limit = 50, Expression<Func<LibraryUser, bool>> filter = null, params Expression<Func<LibraryUser, object>>[] joinedEntities);
        Task<LibraryUser> Insert(LibraryUser user);
        Task Update(LibraryUser user);
        Task<LibraryUser> PartialUpdate(Guid id, JsonPatchDocument<LibraryUser> libraryUser);
    }
}
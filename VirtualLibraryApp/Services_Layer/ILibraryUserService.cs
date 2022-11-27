using Microsoft.AspNetCore.JsonPatch;
using System.Linq.Expressions;
using VL_DataAccess.Models;

namespace Services_Layer
{
    public interface ILibraryUserService
    {
        Task Delete(Guid id);
        Task<LibraryUser> Get(Guid id);
        Task<IEnumerable<LibraryUser>> GetAll(Expression<Func<LibraryUser, bool>> filter = null, params Expression<Func<LibraryUser, object>>[] joinedEntities);
        Task Insert(LibraryUser user);
        Task Update(LibraryUser user);
        Task<LibraryUser> PartialUpdate(Guid id, JsonPatchDocument<LibraryUser> libraryUser);

    }
}
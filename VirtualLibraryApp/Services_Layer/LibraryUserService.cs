using Microsoft.AspNetCore.JsonPatch;
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
    public class LibraryUserService : ILibraryUserService
    {
        readonly IRepository<LibraryUser> _repository;
        public LibraryUserService(IRepository<LibraryUser> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<LibraryUser>> GetAll(Expression<Func<LibraryUser, bool>> filter = null,
           params Expression<Func<LibraryUser, object>>[] joinedEntities)
        {
            return await _repository.GetAll(filter, joinedEntities);
        }

        public async Task<LibraryUser> Get(Guid id) => await _repository.Find(id);

        public async Task Delete(Guid id)
        {
            LibraryUser user = await _repository.Find(id);
            await _repository.Delete(user);
        }

        public async Task Update(LibraryUser user)
        {
            await _repository.Update(user);
        }

        public async Task Insert(LibraryUser user)
        {
            await _repository.Insert(user);
        }

        public async Task<LibraryUser> PartialUpdate(Guid id, JsonPatchDocument<LibraryUser> libraryUser)
        {
            var libraryUserQuery = await Get(id);

            libraryUser.ApplyTo(libraryUserQuery);
            await _repository.SaveChanges();

            return libraryUserQuery;
        }

    }
}

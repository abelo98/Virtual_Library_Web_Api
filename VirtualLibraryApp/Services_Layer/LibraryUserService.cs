using Microsoft.AspNetCore.JsonPatch;
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
    public class LibraryUserService : ILibraryUserService
    {
        readonly IRepository<LibraryUser> _repository;
        readonly VLContext _dbContext;
        public LibraryUserService(IRepository<LibraryUser> repository, VLContext dbContext)
        {
            _repository = repository;
            _dbContext = dbContext;
        }

        public async Task<AllUsers> GetAll(int offset = 0, int limit = 50, Expression<Func<LibraryUser, bool>> filter = null,
           params Expression<Func<LibraryUser, object>>[] joinedEntities)
        {
            AllUsers output = new AllUsers();

            var queryResult = await _dbContext.Users
                .Skip(offset)
                .Take(limit)
                .Select(u => new { user = u, subscriptions = u.SuscribedTo.Count })
                .ToListAsync();

            output.Users = new List<LibraryUser>();
            foreach (var item in queryResult)
            {
                output.Users.Add(item.user);
                output.TotalAuthors += item.subscriptions;
            }

            return output;
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

        public async Task<LibraryUser> Insert(LibraryUser user)
        {
            user.RegisterDate = DateTime.Now;
            return await _repository.Insert(user);
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

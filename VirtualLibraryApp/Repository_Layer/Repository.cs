using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VL_DataAccess;
using VL_DataAccess.Models;

namespace Repository_Layer
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly VLContext _context;

        public Repository(VLContext context)
        {
            _context = context;
        }
        public async Task Delete(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("null entity");

            var entityToDelete = _context.Set<TEntity>().Remove(entity);
            await SaveChanges();
        }

        public async Task<TEntity> Find(params object[]keys)
        {
            return await _context.Set<TEntity>().FindAsync(keys);

        }


        public async Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter = null,
            params Expression<Func<TEntity, object>>[] joinedEntities)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();

            if (filter != null)
                query = query.Where(filter);

            if (joinedEntities != null)
                query = joinedEntities.Aggregate(query, (current, joinedEntity) => current.Include(joinedEntity));

            return await query.ToListAsync();
        }

        public async Task Insert(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("null entity");

            await _context.Set<TEntity>().AddAsync(entity);
            await SaveChanges();
        }


        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("null entity");

            _context.Update(entity);
            await SaveChanges();
        }
    }
}

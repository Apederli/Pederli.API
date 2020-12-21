using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;


namespace Pederli.Core.DataAccess.EntityFreamwork
{
    public class EntityFreamworkBaseQ<TEntity> : IEntityRepositoryQ<TEntity> where TEntity : class
    {
        public  DbContext _context;
        public  DbSet<TEntity> _dbSet;
         
        public EntityFreamworkBaseQ(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }
        public async Task<TEntity> Add(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public async Task<IEnumerable<TEntity>> AddRange(IEnumerable<TEntity> entities)
        {
           await _dbSet.AddRangeAsync(entities);
           return entities;
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public  void DeleteRange(IEnumerable<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public async Task <IEnumerable<TEntity>> Where(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
           return await  _dbSet.Where(predicate).ToListAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
           return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetList()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> SingleOrDefault(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.SingleOrDefaultAsync(predicate); 
        }

        public TEntity Update(TEntity entity)
        {
          _context.Entry(entity).State = EntityState.Modified;

          return entity;
        }
    }
}

using AutoService.Context;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace AutoService.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly AutoDbContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;

        public Repository(AutoDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public TEntity Add(TEntity entity)
        {
            if(entity is null)
            {
                throw new ArgumentNullException();
            }

            _dbSet.Add(entity);

            return entity;
        }

        public void Delete(TEntity entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException();
            }

            _dbSet.Remove(entity);
        }

        public TEntity[] GetAll()
        {
            return _dbSet.ToArray();
        }

        public TEntity[] GetAllByCondition(Expression<Func<TEntity, bool>> condition)
        {
            return _dbSet.Where(condition)
                .ToArray();
        }

        public TEntity GetEntityByConditionOrDefault(Expression<Func<TEntity, bool>> condition)
        {
            return _dbSet.Where(condition)
                .FirstOrDefault();
        }

        public void Update(TEntity entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException();
            }

            _dbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}

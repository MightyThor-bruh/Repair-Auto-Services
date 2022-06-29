using System;
using System.Linq.Expressions;

namespace AutoService.Repository
{
    public interface IRepository<TEntity>
    {
        TEntity[] GetAll();
        TEntity[] GetAllByCondition(Expression<Func<TEntity, bool>> condition);
        TEntity GetEntityByConditionOrDefault(Expression<Func<TEntity, bool>> condition);
        TEntity Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}

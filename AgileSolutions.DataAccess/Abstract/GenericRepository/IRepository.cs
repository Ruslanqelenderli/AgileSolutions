using AgileSolutions.Entity.Entities.CommonEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AgileSolutions.DataAccess.Abstract.GenericRepository
{
    public interface IRepository<TEntity, TReturnResult> : IQuery<TEntity> where TEntity : BaseEntity
    {
        TReturnResult Get(Expression<Func<TEntity, bool>> expression, params string[] include);
        TReturnResult GetAll(Expression<Func<TEntity, bool>>? expression = null,
                             bool enableTracking = true,
                             params string[] include);
        TReturnResult Add(TEntity entity);
        TReturnResult Update(TEntity entity);
        TReturnResult Delete(int Id);
        TReturnResult DeleteRange(ICollection<TEntity> entities);


    }
}

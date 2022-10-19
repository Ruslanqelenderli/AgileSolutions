using AgileSolutions.Entity.Entities.CommonEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AgileSolutions.DataAccess.Abstract.GenericRepository
{
    public interface IAsyncRepository<TEntity, TReturnResult> : IQuery<TEntity> where TEntity : BaseEntity
    {
        Task<TReturnResult> GetAsync(Expression<Func<TEntity, bool>> expression, params string[] include);
        Task<TReturnResult> GetAllAsync(Expression<Func<TEntity, bool>>? expression = null,
                                        bool enableTracking = true,
                                        params string[] include);

        Task<TReturnResult> AddAsync(TEntity entity);
        Task<TReturnResult> UpdateAsync(TEntity entity);
        Task<TReturnResult> DeleteAsync(int Id);
        Task<TReturnResult> DeleteRangeAsync(ICollection<TEntity> entities);
    }
}

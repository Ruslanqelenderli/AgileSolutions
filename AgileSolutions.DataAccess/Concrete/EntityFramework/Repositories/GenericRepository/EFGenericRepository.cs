using AgileSolutions.DataAccess.Abstract.GenericRepository;
using AgileSolutions.DataAccess.Concrete.ReturnResult;
using AgileSolutions.Entity.Entities.CommonEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AgileSolutions.DataAccess.Concrete.EntityFramework.Repositories.GenericRepository
{
    public class EFGenericRepository<TEntity, TReturnResult, TContext> : IRepository<TEntity, TReturnResult>, IAsyncRepository<TEntity, TReturnResult>
         where TEntity : BaseEntity
         where TReturnResult : DataAccessReturnResult<TEntity>, new()
         where TContext : DbContext
    {
        protected readonly TContext context;
        public EFGenericRepository(TContext context)
        {
            this.context = context;
        }

        public IQueryable<TEntity> Query()
        {
            return context.Set<TEntity>();
        }

        #region sync

        public TReturnResult Add(TEntity entity)
        {
            var result = new TReturnResult();
            try
            {
                context.Entry(entity).State = EntityState.Added;
                context.SaveChanges();
                result.MainMethod("Add succeed", true);
                return result;
            }
            catch (Exception ex)
            {
                result.MainMethod(ex.Message, false);
                return result;
            }
        }

        public TReturnResult Delete(int Id)
        {
            var result = new TReturnResult();
            try
            {
                var entity = Query().First(x => x.Id == Id);
                if (entity != null)
                {
                    context.Entry(entity).State = EntityState.Deleted;
                    context.SaveChanges();
                    result.MainMethod("Deleted succeed", true);
                    return result;
                }
                result.MainMethod("This id was not found", false);
                return result;

            }
            catch (Exception ex)
            {
                result.MainMethod(ex.Message, false);
                return result;
            }

        }

        public TReturnResult Get(Expression<Func<TEntity, bool>> expression, params string[] include)
        {
            var result = new TReturnResult();
            try
            {
                var queryable = Query().Where(expression);
                if (include.Count() > 0)
                {
                    foreach (var item in include)
                    {
                        queryable = queryable.Include(item);
                    }
                }
                var list = queryable.ToList();
                result.MainMethod("Get Succeed", true, list);
                return result;
            }
            catch (Exception ex)
            {
                result.MainMethod(ex.Message, false);
                return result;
            }
        }

        public TReturnResult GetAll(Expression<Func<TEntity, bool>>? expression = null,
                                    bool enableTracking = true,
                                    params string[] include)
        {
            var result = new TReturnResult();
            try
            {
                IQueryable<TEntity> queryable = Query();
                if (!enableTracking) queryable = queryable.AsNoTracking();
                if (expression != null) queryable = queryable.Where(expression);
                if (include.Count() > 0)
                {
                    foreach (var item in include)
                    {
                        queryable = queryable.Include(item);
                    }
                }

                var list = queryable.ToList();
                result.MainMethod("GetAll Succeed", true, list);
                return result;
            }
            catch (Exception ex)
            {
                result.MainMethod(ex.Message, false);
                return result;
            }
        }



        public TReturnResult Update(TEntity entity)
        {
            var result = new TReturnResult();
            try
            {
                context.Entry(entity).State = EntityState.Modified;
                context.Entry(entity).Property(x => x.CreatedDate).IsModified = false;
                context.Entry(entity).Property(x => x.IsDeleted).IsModified = false;
                context.Entry(entity).Property(x => x.Id).IsModified = false;
                context.SaveChanges();

                result.MainMethod("Update succeed.", true);
                return result;

            }
            catch (Exception ex)
            {

                result.MainMethod(ex.Message, false);
                return result;
            }

        }

        public TReturnResult DeleteRange(ICollection<TEntity> entities)
        {
            var result = new TReturnResult();
            try
            {

                if (entities != null)
                {
                    context.Entry(entities).State = EntityState.Deleted;
                    context.SaveChanges();
                    result.MainMethod("DeleteRange succeed", true);
                    return result;
                }
                result.MainMethod("This id was not found", false);
                return result;

            }
            catch (Exception ex)
            {
                result.MainMethod(ex.Message, false);
                return result;
            }
        }


        #endregion


        #region async
        public async Task<TReturnResult> GetAsync(Expression<Func<TEntity, bool>> expression, params string[] include)
        {
            var result = new TReturnResult();
            try
            {
                var queryable = Query().Where(expression);
                if (include.Count() > 0)
                {
                    foreach (var item in include)
                    {
                        queryable = queryable.Include(item);
                    }
                }
                var list = await queryable.ToListAsync();
                result.MainMethod("GetAsync succeed", true, list);
                return result;

            }
            catch (Exception ex)
            {
                result.MainMethod(ex.Message, true);
                return result;
            }
        }

        public async Task<TReturnResult> GetAllAsync(Expression<Func<TEntity, bool>>? expression = null,
                                                     bool enableTracking = true,
                                                     params string[] include)
        {
            var result = new TReturnResult();
            try
            {
                var queryable = Query();
                if (!enableTracking) queryable.AsNoTracking();
                if (expression != null) queryable.Where(expression);
                if (include.Count() > 0)
                {
                    foreach (var item in include)
                    {
                        queryable = queryable.Include(item);
                    }
                }

                var list = await queryable.ToListAsync();
                result.MainMethod("GetAll Succeed", true, list);
                return result;

            }
            catch (Exception ex)
            {
                result.MainMethod(ex.Message, false);
                return result;
            }


        }

        public async Task<TReturnResult> AddAsync(TEntity entity)
        {
            var result = new TReturnResult();
            try
            {
                context.Entry(entity).State = EntityState.Added;
                await context.SaveChangesAsync();

                result.MainMethod("AddAsync succeed", true);
                return result;
            }
            catch (Exception ex)
            {
                result.MainMethod(ex.Message, false);
                return result;
            }
        }

        public async Task<TReturnResult> UpdateAsync(TEntity entity)
        {
            var result = new TReturnResult();
            try
            {

                context.Entry(entity).State = EntityState.Modified;
                context.Entry(entity).Property(x => x.CreatedDate).IsModified = false;
                context.Entry(entity).Property(x => x.IsDeleted).IsModified = false;
                context.Entry(entity).Property(x => x.Id).IsModified = false;
                await context.SaveChangesAsync();
                result.MainMethod("UpdateAsync succeed", true);
                return result;
            }
            catch (Exception ex)
            {
                result.MainMethod(ex.Message, false);
                return result;
            }
        }

        public async Task<TReturnResult> DeleteAsync(int Id)
        {
            var result = new TReturnResult();
            try
            {
                var data = Query().First(x => x.Id == Id);
                if (data != null)
                {

                    context.Entry(data).State = EntityState.Deleted;
                    await context.SaveChangesAsync();
                    result.MainMethod("DeletedAsync succeed", true);
                    return result;
                }
                result.MainMethod("This id was not found", false);
                return result;

            }
            catch (Exception ex)
            {
                result.MainMethod(ex.Message, false);
                return result;
            }

        }

        public async Task<TReturnResult> DeleteRangeAsync(ICollection<TEntity> entities)
        {
            var result = new TReturnResult();
            try
            {

                if (entities != null)
                {
                    context.Entry(entities).State = EntityState.Deleted;
                    await context.SaveChangesAsync();
                    result.MainMethod("DeleteRangeAsync succeed", true);
                    return result;
                }
                result.MainMethod("This id was not found", false);
                return result;

            }
            catch (Exception ex)
            {
                result.MainMethod(ex.Message, false);
                return result;
            }
        }



        #endregion

    }
}
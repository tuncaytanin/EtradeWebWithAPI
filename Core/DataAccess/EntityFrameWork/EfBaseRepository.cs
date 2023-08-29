using Core.Entites;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFrameWork
{
    public class EfBaseRepository<TEntity, TDbContext> : IBaseRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TDbContext : DbContext, new()
    {



        public async Task<TEntity> GetByIdAsync(int id)
        {
            using (TDbContext context = new TDbContext())
            {
                return await context.Set<TEntity>().FindAsync(id);
            }
        }

        public async Task<IEnumerable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TDbContext context = new TDbContext())
            {

                return filter == null
                    ? await context.Set<TEntity>().ToListAsync()
                    : await context.Set<TEntity>().Where(filter).ToListAsync();
            }
        }


        public async Task<TEntity> AddAsync(TEntity entity)
        {
            using (TDbContext context = new TDbContext())
            {

                await context.Set<TEntity>().AddAsync(entity);

                await context.SaveChangesAsync();

                return entity;
            }
        }


        public async Task<bool> DeleteByIdAsync(int id)
        {
            using (TDbContext context = new TDbContext())
            {
                var deleteEntity = await context.Set<TEntity>().FindAsync(id);
                bool result = false;
                if (deleteEntity is not null)
                {
                    context.Set<TEntity>().Remove(deleteEntity);
                    await context.SaveChangesAsync();
                    result = true;
                }

                return result;



            }
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            using (TDbContext context = new TDbContext())
            {
                return await context.Set<TEntity>().SingleOrDefaultAsync(filter);
            }
        }



        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            using (TDbContext context = new TDbContext())
            {
                context.Set<TEntity>().Update(entity);
                await context.SaveChangesAsync();
                return entity;
            }
        }
    }
}

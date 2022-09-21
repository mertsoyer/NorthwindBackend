using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityReposiyoryBase<TEntity, TContext> : IEntityRepository<TEntity> where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {

       
        public void Add(TEntity entity)
        {
            var context = new TContext();

            //var addedEntity=context.Add(entity);
            //addedEntity.State = EntityState.Added;
            //context.SaveChanges();

            context.Set<TEntity>().Add(entity);
            context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            var context = new TContext();

            context.Set<TEntity>().Remove(entity);
            context.SaveChanges();

        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            var context = new TContext();
            return context.Set<TEntity>().SingleOrDefault(filter);
        }

        ///
        public IList<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            var context = new TContext();

            return filter==null?context.Set<TEntity>().ToList():context.Set<TEntity>().Where(filter).ToList();
            //Filtre nullsa hepsini listele, eğer filtre varsa where ile filtreye göre listeleme yap.
        }

        public void Update(TEntity entity)
        {
            var context = new TContext();

            context.Set<TEntity>().Update(entity);
            context.SaveChanges();


        }
    }
}

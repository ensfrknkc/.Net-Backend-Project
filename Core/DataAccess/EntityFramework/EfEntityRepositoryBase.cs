using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity,TContext> :IEntityRepository<TEntity>
        where TEntity:class, IEntity, new() 
        where TContext: DbContext, new()
    {
        public void Add(TEntity entity)
        {
            //işlem bittigi gibi bellekten atılsın dıye using kullanılır hızlıca bellegı temızler
            //IDısposıble pattern implementation of c#
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity); //Adres yakalandı (veri kaynagıyla ilişkilendirme)
                addedEntity.State = EntityState.Added; //ekledi
                context.SaveChanges(); //Degisiklikleri kayıt etti
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity); //Adres yakalandı (veri kaynagıyla ilişkilendirme)
                deletedEntity.State = EntityState.Deleted; //Silindi
                context.SaveChanges(); //Degisiklikleri kayıt etti
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            // "? = ise" ": = değilse"
            using (TContext context = new TContext())
            {
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity); //Adres yakalandı (veri kaynagıyla ilişkilendirme)
                updatedEntity.State = EntityState.Modified; //Güncellendi
                context.SaveChanges(); //Degisiklikleri kayıt etti
            }
        }
    }
}

using Domain.Repository;
using infraestrocture.Context;
using Microsoft.EntityFrameworkCore;


namespace infraestrocture.Core
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly AplicationContext aplicationContext;

        //get an sepecific set form the Db
        private readonly DbSet<TEntity> Entity;
        public BaseRepository(AplicationContext context)
        {
            this.aplicationContext = context;
            Entity = aplicationContext.Set<TEntity>();
        }
        public virtual void DeleteEntity(TEntity entity)
        {
            Entity.Remove(entity);
            aplicationContext.SaveChanges();
        }

        public virtual bool Exist(Func<TEntity, bool> filter)
        {
          return  Entity.Any(filter);
        }

        public virtual List<TEntity> FindEntitys(Func<TEntity, bool> filter)
        {
          return  Entity.Where(filter).ToList();
        }

        public virtual List<TEntity> GetAllEntities()
        {
            return [..Entity];
           
        }

        public virtual TEntity GetEntityById(int id)
        {
            // find an specific Entity
           return Entity.Find(id);
          
        }

        public virtual void SaveEnttites(TEntity entity)
        {
            Entity.Add(entity);
            aplicationContext.SaveChanges();
            
        }

        public virtual void UpdateEntity(TEntity entity)
        {
            Entity.Update(entity);
            aplicationContext.SaveChanges();

        }
    }
}

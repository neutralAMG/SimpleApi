

namespace Domain.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        List<TEntity> GetAllEntities();
        List<TEntity> FindEntitys(Func<TEntity, bool> filter);
        bool Exist(Func<TEntity, bool> filter);
        TEntity GetEntityById(int id);
        void SaveEnttites(TEntity entity);
        void UpdateEntity(TEntity entity);
        void DeleteEntity(TEntity entity);
    }
}

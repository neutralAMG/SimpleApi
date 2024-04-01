
namespace Aplication.Core
{
    public interface IBaseSrevice<TGet, TSave, TUpdate>
        where TGet : class
        where TSave : class
        where TUpdate : class
    {
        public ServiceResult<List<TGet>> getEntities();
        public ServiceResult<TGet> getEntity(int id);
        public ServiceResult<TGet> SaveEntity(TSave entity);
        public ServiceResult<TGet> UpdateEntity(TUpdate entity);
        public ServiceResult<TGet> DeleteEntity(int id);
    }
}

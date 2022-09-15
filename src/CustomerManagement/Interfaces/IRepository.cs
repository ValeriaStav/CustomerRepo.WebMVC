using CustomerManagement.BusinessEntities;
using System.Collections.Generic;

namespace CustomerManagement.Interfaces
{
    public interface IRepository<TEntity>
    {
        void Create(TEntity entity);
        TEntity Read(int entity);
        void Update(TEntity entity);
        void Delete(int entity);
        List<TEntity> GetAll();
        void DeleteAll();
    }
}

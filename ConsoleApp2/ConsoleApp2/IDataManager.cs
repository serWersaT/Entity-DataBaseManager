using System.Collections.Generic;

namespace ConsoleApp2
{
    public interface IDataManager
    {
        void Create<TEntity>(TEntity entity) where TEntity : class;

        List<TEntity> SelectAll<TEntity>() where TEntity : class;

        void Update<TEntity>(TEntity entity) where TEntity : class;

        void Delete<TEntity>(int id) where TEntity : class;
    }
}
using System.Collections.Generic;

namespace ConsoleApp2
{
    public interface IDataManager
    {
        void Create<TEntity>(TEntity entity) where TEntity : EntityBase, new();

        List<TEntity> SelectAll<TEntity>() where TEntity : EntityBase, new();

        void Update<TEntity>(TEntity entity) where TEntity : EntityBase, new();

        void Delete<TEntity>(int id) where TEntity : EntityBase, new();
    }
}
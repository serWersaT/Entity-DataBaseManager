using System;
using System.Collections.Generic;
using System.Linq;
using Model.Base;

namespace DataAccess {
    public class DataManager : IDataManager {

        public void Create<TEntity>(TEntity entity) where TEntity : EntityBase, new() {
            using (ModelContainer works = new ModelContainer()) {
                try {
                    works.Set<TEntity>().Add(entity);
                    Console.WriteLine("Новые значения добавлены");
                    works.SaveChanges();
                }
                catch (Exception e) {
                    //logger.Log(e);
                    Console.WriteLine($"Нет подключения к БД\r\n {e}");
                }
            }
        }

        public List<TEntity> SelectAll<TEntity>() where TEntity : EntityBase, new() {
            using (ModelContainer works = new ModelContainer()) {
                var retList = new List<TEntity>();
                foreach (TEntity entity in works.Set<TEntity>()) /*System.InvalidOperationException: "Тип сущности Works не входит в модель для текущего контекста."*/ {
                    var str = entity;
                    retList.Add(str);
                }
                return retList.ToList<TEntity>();
            }

        }

        public void Update<TEntity>(TEntity entity) where TEntity : EntityBase, new() {
            using (ModelContainer works = new ModelContainer()) {
                try {
                    works.SaveChanges();
                }
                catch (Exception e) {
                    Console.WriteLine("Нет подключения к БД: " + e);
                }
            }
        }

        public void Delete<TEntity>(int id) where TEntity : EntityBase, new() {
            using (ModelContainer works = new ModelContainer()) {
                TEntity entity = new TEntity() {
                    Id = id
                };
                works.Set<TEntity>().Attach(entity);
                works.Set<TEntity>().Remove(entity);

                works.SaveChanges();
            }
        }
    }
}
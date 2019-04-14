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
                foreach (TEntity entity in works.Set<TEntity>() /*var row in works.Set<TEntity>()*/) /*System.Data.Entity.Core.MetadataException: "Недопустим как минимум один входной путь, поскольку он превышает допустимую длину или имеет неверный формат. NotSupportedException: Данный формат пути не поддерживается."*/
                                                                                                     /*что такое показать поток в исходном коде?*/
                {
                    var str = entity;
                    //var str = row;
                    retList.Add(str);
                }

                //var retList1 = (from rl in works.VacancySet select works.Set<TEntity>());


                return retList.ToList<TEntity>();
                //return retList1.ToList<TEntity>();      /*Серьезность	Код	Описание Проект	Файл Строка	Состояние подавления Ошибка	CS1929 'IQueryable<DbSet<TEntity>>" не содержит определение для "ToList", и наиболее подходящий перегруженный метод расширения "Enumerable.ToList<TEntity>(IEnumerable<TEntity>)" требует наличия получателя типа "IEnumerable<TEntity>". DataAccess C:\C# проекты\дз entity modal first\7\ConsoleApp\DataAccess\DataManager.cs	38	Активный */
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
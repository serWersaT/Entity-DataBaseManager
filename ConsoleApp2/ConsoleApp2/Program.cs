using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using ConsoleApp2.Base;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Console.WriteLine("Вас приветствует БД по сбору информации о вакансиях!");
            Console.WriteLine("Введите команду: ");

            string team = Console.ReadLine();       
            if (team == "выход") Environment.Exit(0);

            IAction a = null;
            if (team == "добавить") a = new Class_Insert();
            if (team == "показать") a = new Class_Select();
            if (team == "удалить") a = new Class_Delete();
            if (team == "обновить") a = new Class_Updata();*/

            var wm = new DataManager();
            //

            var selectedVacancy = wm.SelectAll<Vacancy>().Where(x=>x.Id==1).SingleOrDefault();
            if (selectedVacancy != null) {
                selectedVacancy.Description = "новое описание";
                wm.Update(selectedVacancy);
            }

            var works = new Vacancy();
            //

            var region = new Region();
            //

            var organization = new Organization();
            //

            /*wm.Create<Works>(works);
            wm.Create<Region>(region);
            wm.Create<Organization>(organization);
            */

            wm.SelectAll<Vacancy>();
            //wm.SelectAll<Region>();
            //wm.SelectAll<Organization>();
            

            Console.ReadLine();          
        }
    }


    public interface IAction
    {
        void Act();
    }


    public class DataManager : IDataManager {
        public void Create<TEntity>(TEntity entity) where TEntity : EntityBase, new() {
            using (Base.ModelContainer works = new Base.ModelContainer()) {
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
            using (Base.ModelContainer works = new Base.ModelContainer()) {
                var retList = new List<TEntity>();
                foreach (TEntity entity in works.Set<TEntity>()) /*System.InvalidOperationException: "Тип сущности Works не входит в модель для текущего контекста."*/ {
                    var str = entity;
                    retList.Add(str);
                }
                return retList.ToList<TEntity>();
            }

        }

        public void Update<TEntity>(TEntity entity) where TEntity : EntityBase, new() {
            using (Base.ModelContainer works = new Base.ModelContainer()) {
                try {
                    works.SaveChanges();
                }
                catch (Exception e) {
                    Console.WriteLine("Нет подключения к БД: " + e);
                }
            }
        }

        public void Delete<TEntity>(int id) where TEntity : EntityBase, new() {
            using (Base.ModelContainer works = new Base.ModelContainer()) {
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

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

            var works = new Works();
            //

            var region = new Region();
            //

            var organization = new Organization();
            //

            /*wm.Create<Works>(works);
            wm.Create<Region>(region);
            wm.Create<Organization>(organization);
            */

            wm.SelectAll<Works>();
            //wm.SelectAll<Region>();
            //wm.SelectAll<Organization>();
            

            Console.ReadLine();          
        }
    }


    public interface IAction
    {
        void Act();
    }


    public class DataManager : IDataManager
    {
        public void Create<TEntity>(TEntity entity) where TEntity : class {
            using (Base.Model1Container works = new Base.Model1Container()) {
                try
                {
                    works.Set<TEntity>().Add(entity);
                    Console.WriteLine("Новые значения добавлены");
                    works.SaveChanges();
                }
                catch(Exception e) {
                    //logger.Log(e);
                    Console.WriteLine($"Нет подключения к БД\r\n {e}");
                }
            }
        }

        public List<TEntity> SelectAll<TEntity>() where TEntity : class {
            //throw new NotImplementedException();


            using (Base.Model1Container works = new Base.Model1Container())     
            {
                var retList = new List<TEntity>();
                foreach (TEntity sss in works.Set<TEntity>())       /*System.InvalidOperationException: "Тип сущности Works не входит в модель для текущего контекста."*/
                {
                    var str = sss;
                    retList.Add(str);
                }
                return retList.ToList<TEntity>();
            }

        }

        public void Update<TEntity>(TEntity entity) where TEntity : class {
            //throw new NotImplementedException();

            using (Base.Model1Container works = new Base.Model1Container())
            {
                Console.WriteLine("Введите номер идентификатора: ");
                try
                {
                    int number = Convert.ToInt32(Console.ReadLine());
                    var work = works.WorksSet.Where(x => x.Id == number).SingleOrDefault();

                    
                }
                catch
                {
                    Console.WriteLine("Число введено не верно");
                }


                try
                {

                    works.SaveChanges();
                }

                catch(Exception e)
                {
                    Console.WriteLine("Нет подключения к БД: " + e);
                }
            }
        }

        public void Delete<TEntity>(int id) where TEntity : class {     // почему тут переменная int id, а не TEntity entity как в Create? 
            //throw new NotImplementedException();
            TEntity ent;
            using (Base.Model1Container works = new Base.Model1Container())
            {
                //works.Set<TEntity>().Remove(id);  /*Серьезность	Код	Описание	Проект	Файл	Строка	Состояние подавления Ошибка CS1503  Аргумент 1: не удается преобразовать из "int" в "TEntity".ConsoleApp2 C:\C# проекты\дз entity modal first\дз\ConsoleApp2\ConsoleApp2\Program.cs	104	Активный*/
                /*поему remove должен принимать аргумент TEntity?????????*/

                works.Set<TEntity>().Remove(10);

                works.SaveChanges();
            }
        }
    }
}

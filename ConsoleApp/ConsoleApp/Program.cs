using DataAccess;
using Model.Base;
using System;
using System.Diagnostics;
using System.Linq;
using System.Text;

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
            works.Id = 2;
            //

            var works1 = new Vacancy() {
                Id = 1
            };

            wm.Create(works);
            wm.Create(works1);
            
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
}

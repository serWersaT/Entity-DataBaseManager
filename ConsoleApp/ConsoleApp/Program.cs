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
            Logger lg = new Logger();
            lg.Log(" Start ");
            var wm = new DataManager();
            //

            /*var selectedVacancy = wm.SelectAll<Vacancy>().Where(x=>x.Id==1).SingleOrDefault();
            if (selectedVacancy != null) {
                selectedVacancy.Description = "новое описание";
                wm.Update(selectedVacancy);
            }*/

            var works = new Vacancy();
            works.Id = 0;
            works.Vakancy = "Работник";
            works.RegionName  = "Калуга";
            works.Salary = "1 руб";
            works.OrganizationName = "Рога и копыта";
            works.Person = "Дядя Вася";
            works.Phone = "1234567890";
            works.Type = "от рассета до заката";
            works.Description = "потом разберемся";
            works.RegionId = 0;
            works.OrganizationId = 0;
            //

            var works1 = new Vacancy(); 
            works1.Id = 1;
            works1.Vakancy = "Сотрудник";
            works1.RegionName  = "Калуга";
            works1.Salary = "2 руб";
            works1.OrganizationName = "Рога и копыта";
            works1.Person = "Дядя Федя";
            works1.Phone = "1234567890";
            works1.Type = "от рассета до заката";
            works1.Description = "потом разберемся";
            works1.RegionId = 1;
            works1.OrganizationId = 1;

            wm.Create(works);
            wm.Create(works1);
            
            var region = new Region();
            //

            var organization = new Organization();
            //

            wm.Create<Vacancy>(works);
            wm.Create<Vacancy>(works1);
            /*wm.Create<Region>(region);
            wm.Create<Organization>(organization);*/
            

            wm.SelectAll<Vacancy>();
            //wm.SelectAll<Region>();
            //wm.SelectAll<Organization>();
            

            Console.ReadLine();          
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp2
{
    public class Class_Updata: IAction
    {

        string table;
        public void Act()
        {
            Console.WriteLine("Введите название таблицы");
            table = Console.ReadLine();
            if (table == "вакансии") Update_Vacancy();
        }
        public void Update_Vacancy()
        {
                using (Base.Model1Container works = new Base.Model1Container())
                {
                    var VacancyBD = new Base.Works();

                    Console.WriteLine("Введите номер идентификатора: ");
                    try
                    {
                        int number = Convert.ToInt32(Console.ReadLine());
                        var work = works.WorksSet.Where(x=>x.Id==number).SingleOrDefault();
                        
                    }
                    catch
                    {
                        Console.WriteLine("Число введено не верно");
                    }
                    
                    if (VacancyBD.Vakancy != null)
                    {
                        Console.WriteLine("Введите название новой вакансии:");
                        VacancyBD.Vakancy = Console.ReadLine();
                        Console.WriteLine("Введите название региона вакансии:");
                        VacancyBD.Region = Console.ReadLine();
                        VacancyBD.RegionId++;
                        Console.WriteLine("Введите величину оклада:");
                        VacancyBD.Salary = Console.ReadLine();
                        Console.WriteLine("Введите название организации:");
                        VacancyBD.Organization = Console.ReadLine();
                        VacancyBD.OrganizationId++;
                        Console.WriteLine("Введите контактное лицо:");
                        VacancyBD.Person = Console.ReadLine();
                        Console.WriteLine("Введите контактный номер:");
                        VacancyBD.Phone = Console.ReadLine();
                        Console.WriteLine("Введите тип занятости:");
                        VacancyBD.Type = Console.ReadLine();
                        Console.WriteLine("Введите описание новой вакансии:");
                        VacancyBD.Description = Console.ReadLine();

                        try
                        {
                            works.SaveChanges();
                        }

                        catch { Console.WriteLine("Нет подключения к БД"); }
                    }
                }           
        }






    }
}

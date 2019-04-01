using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace ConsoleApp2
{
    public class Class_Insert : IAction
    {

        string table;
        public void Act()
        {
            Console.WriteLine("Введите название таблицы");
            table = Console.ReadLine();
            if (table == "вакансии") Insert_Vacancy();
            if (table == "регионы") Insert_Region();
            if (table == "организации") Insert_Organization();
        }
        public void Insert_Vacancy()
        {
                using (Base.Model1Container works = new Base.Model1Container())
                {
                    var VacancyBD = new Base.Works();
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
                        works.WorksSet.Add(VacancyBD);
                        Console.WriteLine("Новые значения добавлены");
                        works.SaveChanges();
                    }

                    catch { Console.WriteLine("Нет подключения к БД"); }
                }
        }


        public void Insert_Region()
        {
                using (Base.Model1Container works1 = new Base.Model1Container())
                {
                    var RegionBD = new Base.Region();
                    Console.WriteLine("Введите название нового региона:");
                    RegionBD.Name = Console.ReadLine();
                    Console.WriteLine("Введите средний доход региона:");
                    RegionBD.Average_salary = Console.ReadLine();
                    Console.WriteLine("Введите сложность трудоустройства в регионе:");
                    RegionBD.Complexity = Console.ReadLine();

                    try
                    {
                        works1.RegionSet.Add(RegionBD);
                        Console.WriteLine("Новые значения добавлены");
                        works1.SaveChanges();
                    }

                    catch { Console.WriteLine("Нет подключения к БД"); }

                }
        }


        public void Insert_Organization()
        {
                using (Base.Model1Container works2 = new Base.Model1Container())
                {
                    var OrganizationBD = new Base.Organization();
                    Console.WriteLine("Введите количество работников организации:");
                    OrganizationBD.Employees = Console.ReadLine();
                    Console.WriteLine("Введите дату создания организации:");
                    OrganizationBD.Date = Console.ReadLine();
                    Console.WriteLine("Введите адресс организации:");
                    OrganizationBD.Adress = Console.ReadLine();

                    try
                    {
                        works2.OrganizationSet.Add(OrganizationBD);
                        Console.WriteLine("Новые значения добавлены");
                        works2.SaveChanges();
                    }

                    catch { Console.WriteLine("Нет подключения к БД"); }

                }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp2
{
    public class Class_Delete: IAction
    {

        string table;
        public void Act()
        {
            Console.WriteLine("Введите название таблицы");
            table = Console.ReadLine();
            if (table == "вакансии") Delete_Vacancy();
            if (table == "регионы") Delete_Region();
            if (table == "организации") Delete_Organization();
        }
        public void Delete_Vacancy()
        {
                Console.WriteLine("Введие номер стоки, которую собираетесь удалить");

                try
                {
                    int number = Convert.ToInt32(Console.ReadLine());

                    using (Base.Model1Container works = new Base.Model1Container())
                    {
                        var VacancyBD = new Base.Works();
                        VacancyBD.Vakancy.Remove(number);
                        works.SaveChanges();
                    }
                }
                catch
                {
                    Console.WriteLine("Номер строки введен не верно");
                }           
        }

        public void Delete_Region()
        {
                Console.WriteLine("Введие номер стоки, которую собираетесь удалить");

                try
                {
                    int number = Convert.ToInt32(Console.ReadLine());

                    using (Base.Model1Container works1 = new Base.Model1Container())
                    {
                        var RegionBD = new Base.Region();
                        RegionBD.Name.Remove(number);
                        works1.SaveChanges();
                    }
                }
                catch
                {
                    Console.WriteLine("Номер строки введен не верно");
                }
        }

        public void Delete_Organization()
        {
                Console.WriteLine("Введие номер стоки, которую собираетесь удалить");

                try
                {
                    int number = Convert.ToInt32(Console.ReadLine());

                    using (Base.Model1Container works2 = new Base.Model1Container())
                    {
                        var OrganizationBD = new Base.Organization();
                        OrganizationBD.Employees.Remove(number);
                        works2.SaveChanges();
                    }
                }
                catch
                {
                    Console.WriteLine("Номер строки введен не верно");
                }
        }
    }
}

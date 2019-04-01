using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp2
{
    public class Class_Select : IAction
    {
        
        public void Act()
        {
            string table;
            Console.WriteLine("Введите название таблицы");
            table = Console.ReadLine();
            if (table == "вакансии") Select_Vacancy();
            if (table == "регионы") Select_Region();
            if (table == "организации") Select_Organization();
        }

        void Select_Vacancy()
        {
                using (Base.Model1Container works = new Base.Model1Container())
                {
                    var VacancyBD = new Base.Works();

                    for (int i = 0; i <= VacancyBD.Id; i++)
                    {
                        Console.WriteLine(VacancyBD.Id.ToString() + " | " + VacancyBD.Vakancy + " | " + VacancyBD.Region + " | " + VacancyBD.Salary + " | " + VacancyBD.Organization
                            + " | " + VacancyBD.Person + " | " + VacancyBD.Phone + " | " + VacancyBD.Type + " | " + VacancyBD.Description + " | " + "\r\n");
                    }               
                }
        }

        public void Select_Region()
        {
                using (Base.Model1Container works = new Base.Model1Container())
                {
                    var RegionBD = new Base.Region();

                    for (int i = 0; i <= RegionBD.Id; i++)
                    {
                        Console.WriteLine(RegionBD.Id.ToString() + " | " + RegionBD.Name + " | " + RegionBD.Average_salary + " | " + RegionBD.Complexity + " | " + "\r\n");
                    }               
                }
        }

        public void Select_Organization()
        {
                using (Base.Model1Container works = new Base.Model1Container())
                {
                    var OrganizationBD = new Base.Organization();
                    for (int i = 0; i <= OrganizationBD.Id; i++)
                    {
                        Console.WriteLine(OrganizationBD.Id.ToString() + " | " + OrganizationBD.Employees + " | " + OrganizationBD.Date + " | " + OrganizationBD.Adress + " | " + "\r\n");
                    }
                }
        }
    }
}

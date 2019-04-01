using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleApp2.Base;

namespace ConsoleApp2
{
    class Base_Table
    {
        public void All_tables()
        {

            using (Base.Model1Container work = new Base.Model1Container())
            {
                var wm = new DataManager();
                //

                var works = new Works();
                //

                var region = new Region();
                //

                var organization = new Organization();

                wm.Create<Works>(works);
                wm.Create<Region>(region);
                wm.Create<Organization>(organization);
            }
        }
    }
}

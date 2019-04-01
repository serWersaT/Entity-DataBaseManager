using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp2
{
    class Logger
    {
        public void Log(string msg)
        {
            DateTime currtime = DateTime.Now;
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"log.txt", true))
            {
                string tmptxt = String.Format("{0:dd.mm.yy hh:mm:ss} {1}", currtime, msg);
                file.WriteLine(tmptxt);
                file.Close();
            }
        }
    }
}

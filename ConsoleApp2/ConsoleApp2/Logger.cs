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
            string str = msg;
            const string log1 = "log1.txt";
            const string log2 = "log2.txt";

            try
            {
                logger(log1, str);
            }

            catch
            {
                logger(log2, str);
            }
            
        }

        private void logger(string filename, string str)
        {
            DateTime currtime = DateTime.Now;
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(filename, true))
            {
                string tmptxt = String.Format("{0:dd.mm.yy hh:mm:ss} {1}", currtime, str);
                file.WriteLine(tmptxt);
                file.Close();
            }
        }
    }
}

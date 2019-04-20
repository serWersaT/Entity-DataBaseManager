using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp2
{
    public class LoggerExperiments {
        public delegate void A(string m);

        public A SomeDelegate;


        public event Action<string> SomeEvent;

        protected virtual void OnSomeEvent(string obj) {
           SomeEvent?.Invoke("Это из эвента" + obj);
        }


        public Func<int, int, string> B;

        
        public void ActionA(string msg) {
            Console.WriteLine($"Это из ActionA: {msg}");
        }

        public void Log(string msg) {
            Action<int, string> a = (i, s) => {};
            a.Invoke(1, "str");

            B = (i, j) => {
                return "";
            };

            string a1 = "a1";
            var b1 = "b1";
            var c1 = "c1";


            b1 = a1 ?? c1;
            Console.WriteLine(b1);

            
            Console.WriteLine($"Началось выполнение метода Log");
            SomeDelegate += x => {
                Console.WriteLine($"Это из ActionA: {msg}");
            };
            
            string str = msg;
            const string log1 = "log1.txt";
            const string log2 = "log2.txt";

            OnSomeEvent(msg);

            try
            {
                logger(log1, str);
            }

            catch
            {
                logger(log2, str);
            }
            Console.WriteLine($"Закончилось выполнение метода Log");
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

    public class A {
        readonly LoggerExperiments _logger;

        public A(LoggerExperiments logger) {
            _logger = logger;
            //_logger.SomeEvent += s => Console.WriteLine(s);
        }


        public void Abbbb() {
            _logger.Log("Message1");
        }


        public void Acccc() {
            _logger.SomeDelegate("Message2");
            _logger.B(1, 2);
        }
    }
}

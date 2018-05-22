using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2
{
    class Program
    {
        static void Main(string[] args)
        {
            int steps = 100000;
            System.Diagnostics.Stopwatch s = new System.Diagnostics.Stopwatch();

            s.Start();
            StringBuilder test1 = new StringBuilder();
            for (int i = 1; i <= steps; i++)
            {
                test1.Append(i.ToString());
            }
            s.Stop();
            Console.WriteLine("String is {0} characters long", test1.Length);
            Console.WriteLine(s.Elapsed);

            s.Reset();

            s.Start();
            string test = string.Empty;
            for (int i = 1; i <= steps; i++)
            {
                test = test + i.ToString();
            }
            s.Stop();
            Console.WriteLine("String is {0} characters long", test.Length);
            Console.WriteLine(s.Elapsed);
            
            Console.ReadKey();
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MO_Lab2
{
    class Program
    {
        private const int count = 3;

        static void Main(string[] args)
        {
            double EPS = 0.00000001;
            Interval interval = new Interval();

            Console.WriteLine("Алгоритм Брента:");
            for (int i = 1; i <= count; i++)
            {
                interval = Functions.GetInterval(i);
                Console.WriteLine(BrentMethod.BrentCalc(interval.A, interval.B, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, EPS, i, true));
            }
            Console.ReadKey();

        }
    }
}

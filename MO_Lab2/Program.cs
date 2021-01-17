
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MO_Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrix = new Matrix(3, new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            Console.WriteLine("Initial Matrix");
            matrix.showMatrix();
            Console.WriteLine("----------------------");

            matrix.LU();
            Console.WriteLine("L Matrix");
            matrix.showL();
            Console.WriteLine("----------------------");

            Console.WriteLine("U Matrix");
            matrix.showU();
            Console.WriteLine("----------------------");

            Console.ReadKey();
        }
    }
}

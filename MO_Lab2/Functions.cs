using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MO_Lab2
{
    public class Interval
    {
        private double a, b;

        public double A
        {
            get => a;
            set => a = value;
        }

        public double B
        {
            get => b;
            set => b = value;
        }
    }

    public class Functions
    {
        public static double function(double x1, double x2, int k, double? x3 = null, double? x4 = null)
        {
            double res;
            switch (k)
            {
                case 1:
                    res = 100 * Math.Pow(x2 - Math.Pow(x1, 2), 2) + Math.Pow(1 - x1, 2);
                    break;
                case 2:
                    res = Math.Pow(x2 - Math.Pow(x1, 2), 2) + Math.Pow((1 - x1), 2);
                    break;
                case 3:
                    res = Math.Pow(1.5 - x1 * (1 - x2), 2) - Math.Pow(2.25 - x1 * (1 - Math.Pow(x2, 2)), 2) + Math.Pow(2.625 - x1 * (1 - Math.Pow(x2, 3)), 2);
                    break;
                case 4:
                    res = Math.Pow(x1 + x2, 2) - 5 * Math.Pow(x3.Value - x4.Value, 2) + Math.Pow(x2 - 2 * x3.Value, 4) + 10 * Math.Pow(x1 - x4.Value, 4);
                    break;
                default:
                    res = 0;
                    break;
            }

            return res;
        }

        public static Interval GetInterval(int k)
        {
            Interval interval = new Interval();
            switch (k)
            {
                case 1:
                    interval.A = -0.5;
                    interval.B = 0.5;
                    break;
                case 2:
                    interval.A = 6;
                    interval.B = 9.9;
                    break;
                case 3:
                    interval.A = 0;
                    interval.B = 2 * Math.PI;
                    break;
                case 4:
                    interval.A = 0;
                    interval.B = 1;
                    break;
                case 5:
                    interval.A = 0.5;
                    interval.B = 2.5;
                    break;
                case 6:
                    interval.A = 1;
                    interval.B = 5;
                    break;
                default:
                    break;
            }

            return interval;
        }
    }
}

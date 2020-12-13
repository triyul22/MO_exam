using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MO_Lab2
{
    class BrentMethod
    {
        private static double FuncCalc(double x, int k)
        {
            if(k == 1)
            {
                return -1 * Math.Pow(x, 5) + 4 * Math.Pow(x, 4) - 12 * Math.Pow(x, 3) + 11 * Math.Pow(x, 2) - 2 * x + 1;
            }
            else if(k == 2)
            {
                return -3 * x * Math.Sin(0.75 * x) + Math.Exp(-2 * x);
            }
            else if(k == 3)
            {
                return Math.Exp(3 * x) + 5 * Math.Exp(-2 * x);
            }
            else
            {
                return 0.0;
            }
        }

        private static double DerivCalc(double x, int k)
        {
            if (k == 1)
            {
                return -5 * Math.Pow(x, 4) + 16 * Math.Pow(x, 3) - 36 * Math.Pow(x, 2) + 22 * x - 2;
            }
            else if (k == 2)
            {
                return -3 * Math.Sin(0.75 * x) - 2.25 * Math.Cos(0.75 * x) - 2 * x * Math.Exp(-2 * x);
            }
            else if (k == 3)
            {
                return 3 * Math.Exp(3 * x) - 10 * Math.Exp(-2 * x);
            }
            else
            {
                return 0.0;
            }
        }

        private static double XCalc(double x1, double x2, double f1, double f2)
        {
            var a = (f2 - f1) / (x2 - x1);
            var b = f1 - x1 * a;
            return -b / a;
        }

        //x наименьшее значение функции
        //w 2-е снизу значение ф-и
        //v предыдущее значение w

        public static double BrentCalc(double a, double c, double prev_u, double x, double w, double v, double d, double e, double fa, double fc, double fx, double fw, double fv, double f_x, double f_w, double f_v, double EPS, int i, bool isFirst = false)
        {
            if (isFirst)
            {
                x = w = v = (a + c) / 2;
                fx = fw = fv = FuncCalc(x, i);
                f_x = f_w = f_v = DerivCalc(x, i);
                d = c - a;
                e = c - a;
                prev_u = -1;
            }
            if (Math.Abs(c - a) < 2 * EPS)
            {
                return (c + a) / 2;
            }
            double fu;
            double f_u;
            double g;
            double u = 0;
            g = e;
            e = d;

            double? u1 = null;
            double? u2 = null;
            if(x != w && f_x != f_w)
            {
                var u1_temp = XCalc(f_x, f_w, x, w);
                if (u1_temp > a + EPS && u1_temp < c + EPS && Math.Abs(u1_temp - x) < g / 2)
                {
                    u1 = u1_temp;
                }
            }
            if (x != v && f_x != fv)
            {
                var u2_temp = XCalc(f_x, f_v, x, v);
                if(u2_temp > a + EPS && u2_temp < c + EPS && Math.Abs(u2_temp - x) < g / 2)
                {
                    u2 = u2_temp;
                }
            }
            if (u1.HasValue || u2.HasValue)
            {
                u = u1.HasValue && u2.HasValue && Math.Abs(u1.Value - x) < Math.Abs(u2.Value - x) || u1.HasValue && !u2.HasValue
                    ? u1.Value
                    : u2.Value;
            }
            else
            {
                u = f_x > 0 
                    ? (a + x) / 2 
                    : (a + c) / 2;
            }
            if(Math.Abs(u - x) < EPS)
            {
                u = x + Math.Sign(u - x) * EPS;
            }
            d = Math.Abs(x - u);

            fu = FuncCalc(u, i);
            f_u = DerivCalc(u, i);

            if(fu <= fx)
            {
                if (u >= x) { a = x; }
                else { c = x; }
                v = w; w = x; x = u; fv = fw; fw = fx; fx = fu; f_v = f_w; f_w = f_x; f_x = f_u;
            }
            else
            {
                if(u >= x) { c = u; }
                else { a = u; }
                if(fu <= fw || w == x)
                {
                    v = w; w = u; fv = fw; fw = fu; f_v = f_w; f_w = f_u;
                }
                else if(fu <= fv || v == x || v == w)
                {
                    v = u; fv = fu; f_v = f_u;
                }
            }
            if(Math.Abs(prev_u - u) <  EPS)
            {
                return (c + a) / 2;
            }

            return BrentCalc(a, c, u, x, w, v, d, e, fa, fc, fx, fw, fv, f_x, f_w, f_v, EPS, i);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace timp
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Введите x, y , шаг");
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());
            double n = double.Parse(Console.ReadLine());
            double[] a = new double[(int)(10 / n) + 1];
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = fynk(x, y);
                x += n;
            }
            vivod(a);
            Console.WriteLine(a[0]);
            Console.ReadKey();
        }
        public static double fynk(double x, double y)
        {
            if (x + y == 0)
            {
                return Math.Cos(Math.Pow(x, 2)) + Math.Cos(y);
            }
            else if (x - y > 0)
            {
                return Math.Tan(Math.Pow(x, 2) + y);
            }
            else
            {
                return Math.Pow(Math.Sin(x), 2) + Math.Cos(x * y);
            }
        }
        public static void vivod(double[] a1)
        {
            for (int i = 0; i < a1.Length; i++)
            {
                Console.WriteLine("a[" + i + "]= " + a1[i]);
            }

        }
        
    }
}

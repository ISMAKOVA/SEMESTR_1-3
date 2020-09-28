using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ТСИСА
{
    class Program
    {
        public static double A = 0.4001;
        public static double B = -0.0014;
        public static double C = 3.9996;
        static void Main(string[] args)
        {

            var x0 = -5;
            var h = 0.1;
            var res = SvenAlgorithm(x0, h);
            var a = res[0];
            var b = res[1];
            var e = 0.001;
            var n = 1000;
            Console.WriteLine($"Полученный отрезок с помощью алгоритм Свенна:[{a},{b}]");
            if (IsUnimodal())
                Console.WriteLine("Квадратичная функция унимодальна");
            else Console.WriteLine("Квадратичная функция не унимодальна");

            Console.WriteLine("\nМинимальное значение");

            Console.WriteLine("Методом деления отрезка пополам: {0} ", SqFunc(DichotomySearch(a, b, e)));
            Console.WriteLine("Методом золотого сечения: {0} ", SqFunc(GoldenSearch(a, b, e)));
            Console.WriteLine("Методом пассивного поиска: {0}", SqFunc(PassiveSearch(a, b, n)));
            Console.WriteLine("Методом Фибоначчи: {0}", SqFunc(FibonacciSearch(a, b, e)));
            Console.ReadLine();

        }
        //Квадратичная функция
        static double SqFunc(double x)
        {
            return A * x * x + B * x + C;
        }

        //Производная 1-го порядка 
        static double Diff(double x)
        {
            return 2* A * x + B;
        }

        //Поризводная 2-го порядка
        static double Diff2()
        {
            return 2*A;
        }

        //Проверка на унимодальность

        static bool IsUnimodal()
        {
            return Diff2() > 0;
        }

        //Алгоритм Свенна
        static double [] SvenAlgorithm(double x0, double h)
        {

            var result = new double[2]; 
            while (true)
            {
                var a = x0 - h;
                var b = x0 + h;
                var F0 = SqFunc(x0);
                var F1 = SqFunc(a);
                var F2 = SqFunc(b);
                if (F1 >= F0 && F0 <= F2)
                {
                    result[0]=a;
                    result[1]=b;
                    return result;
                }
                else if (F1 <= F0 && F0 <= F2)
                    x0 -= 2 * h;
                else x0 += 2 * h;

            }
        }
        
        //Метод деления отрезка пополам
        static double DichotomySearch(double a, double b, double e)
        {
            double d = e / 4;
            double res = 0;
            while (Math.Abs(b - a) >= e)
            {
                var x1 = (a + b) / 2 - d;
                var x2 = (a + b) / 2 + d;
                var F1 = SqFunc(x1);
                var F2 = SqFunc(x2);
                if (F1 < F2)
                    b = x2;
                else if (F1 > F2)
                    a = x1;
                else
                {
                    a = x1;
                    b = x2;
                }
                res = (a + b) / 2;
            }
            return res;
        }

        //Метод золотого сечения
        static double GoldenSearch(double a, double b, double e)
        {
            var k = (Math.Sqrt(5) - 1) / 2;//коэф зжатия, "золотое" число
            var x1 = a + (1 - k) * (b - a);
            var x2 = a + k * (b - a);
            var F1 = SqFunc(x1);
            var F2 = SqFunc(x2);
            double res = 0;
            while (Math.Abs(b - a) >= e)
            {
                if (F1 < F2)
                {
                    b = x2;
                    x2 = x1;
                    F2 = F1;
                    x1 = a + (1 - k) * (b - a);
                    F1 = SqFunc(x1);
                }
                else if (F1 > F2)
                {
                    a = x1;
                    x1 = x2;
                    F1 = F2;
                    x2 = a + k * (b - a);
                    F2 = SqFunc(x2);
                }
                else
                {
                    a = x1;
                    b = x2;
                }
                res=(a + b) / 2;
            }
            return res;
        }


        //Метод пассивного поиска
        static double PassiveSearch(double a,double b,int n)
        {
            var h = (b - a) / (double)n;
            var x = new double[n + 1];
            for(int i = 0; i < n + 1; i++)
            {
                x[i] = a + i * h;
            }
            for(int i = 1; i < n; i++)
            {
                if (SqFunc(x[i - 1]) > SqFunc(x[i]) && SqFunc(x[i]) < SqFunc(x[i + 1]))
                    return x[i];
            }
            return 0;
        }


        //Последовательность первых n членов последовательности Фибоначчи c#
        static List<int> F(int n)
        {
            var nums = new List<int>();
            for (int i = 0; i < n; i++)
            {
                if (i < 2) nums.Add(1);
                else nums.Add(nums[i - 1] + nums[i - 2]);
            }
            return nums;
        }
        //Метод Фибоначчи
        static double FibonacciSearch(double a, double b,  double e)
        {
            int n = 10;
            double min = 0;
            var f = F(n + 1);
            for (int i = 1; i < n; i++)
            {
                var x1 = a + (b - a) * f.ElementAt(n - i - 1) / f.ElementAt(n - i + 1) - (Math.Pow(-1, n - i + 1) * e) / f.ElementAt(n - i + 1);
                var x2 = a + (b - a) * f.ElementAt(n - i) / f.ElementAt(n - i + 1) + (Math.Pow(-1, n - i + 1) * e) / f.ElementAt(n - i + 1);
                var F1 = SqFunc(x1);
                var F2 = SqFunc(x2);
                if (F1 < F2)
                    b = x2;
                else if (F1 >= F2)
                    a = x1;
                else
                {
                    a = x1;
                    b = x2;
                }
                if (a < x1 && x1 < b)
                    min = x1;
                else min = x2;
            }
            return min;

            
        }
    }
}

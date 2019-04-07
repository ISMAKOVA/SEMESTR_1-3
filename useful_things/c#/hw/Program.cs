using System;

namespace hw
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("число");
            int c = Int32.Parse(Console.ReadLine());
            Console.WriteLine("введите степень");
            Console.WriteLine("#1");
            int n = Int32.Parse(Console.ReadLine());
            int result = 1;
            int counter = 0;
            while (counter != n)
            {
                result *= c;
                counter++;
            }
            Console.WriteLine(result);
            Console.WriteLine("#2");
            //int r = Int32.Parse(Console.ReadLine());
            int rr = task2(n, c);
            Console.WriteLine(rr);
        }
         static int task2(int n, int c)
        {
            int result = 1;
           //int counter = 0;
            while (n>0)
            {
                if (n % 2 == 0)
                {
                    n =n/ 2;
                    c *= c;
                }
                else
                {
                    n--;
                    result *= c;
                }
            }
            return result;
        }
    }
}

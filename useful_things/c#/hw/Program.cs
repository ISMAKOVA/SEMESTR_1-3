using System;

namespace hw
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int n = Int32.Parse(Console.ReadLine());
            int c = 2;
            int result = 1;
            int counter = 0;
            while (counter != n)
            {
                result *= c;
                counter++;
            }
            Console.WriteLine(result);
        }
         static int task2(int n, int c)
        {
            int res = 1;
            int counter = 0;
            while (n!=counter)
            {
                if (n % 1==0)
                    res *= c;
                c *= c;
                n++;
                counter++;
            }
            return res;
        }
    }
}

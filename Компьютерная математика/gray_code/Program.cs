using System;

namespace gray_code
{
    class MainClass
    {
       
        public static void Main(string[] args)
        {
            task2();
        }
        public static void task2()
        {
            Console.WriteLine("Введите множество:");
            string[] U = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            int n = U.Length;//мощность мн-ва
            byte[] B = new byte[n];
            for(int i = 0; i < n; i++)
            {

                B[i] = 0;
            }
            Console.WriteLine(B);
            int pow =Convert.ToInt32( Math.Pow(2, n));
            int p;
            for(int i = 1; i < pow - 1; i++)
            {
                p = Q(i);
                B[p] = Convert.ToByte(1 - Convert.ToInt32(B[p]));
                Console.WriteLine(B);
            }

        }
        public static int Q(int i)
        {
            int q = 1;
            int j = i;
            while (j % 2 == 0)
            {
                j = j / 2;
                q = q + 1;
            }
            return q;
        }
    }
}

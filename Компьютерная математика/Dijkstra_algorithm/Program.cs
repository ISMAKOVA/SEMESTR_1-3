using System;

namespace Dijkstra_algorithm
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int INF = 200000000;
            Console.WriteLine("Введите размерность матрицы");
            int n = Int32.Parse(Console.ReadLine());
        m1:

            int[,] C = new int[n, n];
            int[] T = new int[n];
            int[] X = new int[n];
            int[] H = new int[n];

            string[] r = new string[n];
            for (int i = 0; i < n; i++)
            {
                T[i] = INF;
                X[i] = 0;
                r = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < n; j++)
                {
                    try
                    {
                        if (r[j] == "i")
                        {
                            C[i, j] = INF;
                        }
                        else
                            C[i, j] = Int32.Parse(r[j]);

                    }
                    catch
                    {
                        Console.WriteLine("Повторите ввод");
                        goto m1;
                    }
                }
            }

            Console.WriteLine("Введите v0");
            int s = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Введите v1");
            int t = Int32.Parse(Console.ReadLine());

            H[s] = 0;
            T[s] = 0;
            X[s] = 1;

            for(int i = 0; i < n; i++)
            {

            }


        }
    }
}

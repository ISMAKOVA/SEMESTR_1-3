using System;

namespace Floyd_algorithm_2
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int INF = 200000000;
            Console.WriteLine("Введите размерность матрицы");
            int n = Int32.Parse(Console.ReadLine());
        m1:

            int[,] T = new int[n, n]; 
            int[,] C = new int[n, n];
            int[,] H = new int[n, n];

            string[] r = new string[n];
            for (int i = 0; i < r.Length; i++)
            {

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
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == j) { C[i, j] = 0; }
                    T[i, j] = C[i, j];


                    if (C[i, j] == INF)
                    {
                        H[i, j] = 0;
                    }
                    else

                        H[i, j] = j+1;
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        if (T[j, i] + T[i, k] < T[j, k]) 
                        {
                            T[j, k] = T[j, i] + T[i, k];//длина нового пути
                            H[j, k] = H[j, i];//новый путь
                        }
                    }
                    if (T[j, j] < 0)
                    {
                        return;
                    }
                }
            }


            Console.WriteLine("Матрица кратчайших путей");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {


                    if (T[i, j] == INF)
                    {
                        Console.Write("i ");
                    }
                    else
                    Console.Write(T[i, j] + " ");

                    if (j % n == 0 && j > 0)
                    {
                        i++;
                    }

                }
                Console.WriteLine();
            }
            Console.WriteLine("Полный путь");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(H[i, j] + " ");

                    if (j % n == 0 && j > 0)
                    {
                        i++;
                    }
                }
                Console.WriteLine();
            }


            Console.WriteLine("Введите v0");
            int w = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Введите v1");
            int two = Int32.Parse(Console.ReadLine());
            Console.Write(w + " ");

            int z = w;
            while (H[z-1, two-1] != two)
            {
                Console.Write(H[z-1, two-1]+" ");
                z = H[z-1, two-1];
            }

            Console.Write(two + " ");

            Console.ReadKey();
        }


    }
}

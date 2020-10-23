using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace dfs
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Введите размерность матрицы");
            int n = Int32.Parse(Console.ReadLine());
        m1:
            int[,] C = new int[n, n];
            int[] u = new int[n];
            string[] r = new string[n];
            for (int i = 0; i < n; i++)
            {

                r = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < n; j++)
                {
                    try
                    {
                        C[i, j] = Int32.Parse(r[j]);
                        u[i] = 0;
                    }
                    catch
                    {
                        Console.WriteLine("Повторите ввод");
                        goto m1;
                    }
                }
            }

            for(int i = 0; i < n; i++)
            {
                DFS(u[i], u);
            }

        }
        public static void DFS(int v,int [] mark)
        {
            if (mark[v] != 0)  
            {
                return;
            }
            mark[v] = 1;

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;


namespace warshall_algorithm
{
    class MainClass
    {
        public static void Hash(String[] S, HashSet<string> A)
        {
            for (int k = 0; k < S.Length; k++)
            {
                A.Add(S[k]);
            }
        }
        //ввод множества пар
        public static HashSet<string> Generate(string[] mas)
        {
            int l = mas.Length;
            string s;
            HashSet<string> result = new HashSet<string>();

            for (int i = 0; i < l; i++)
            {
                for (int j = 0; j < l; j++)
                {
                    s = "(" + mas[i] + "," + mas[j] + ")";
                    result.Add(s);
                }

            }
            return result;
        }
        public static void Main(string[] args)
        {
            string[] M = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            HashSet<string> U = new HashSet<string>();
            Hash(M, U);//избавляемся от повторений
            string[] X = new string[0];
            for (int i = 0; i < U.Count; i++)
            {
                Array.Resize(ref X, X.Length + 1);
                X[i] = U.ElementAt(i);
            }
            int N = X.Length;//мощность множества Х 
            Console.WriteLine("Множество пар множества Х:");
            foreach (string t in Generate(X))
            {
                Console.Write(t + " ");
            }
            Console.WriteLine();

            Console.WriteLine("Введите отношение R:");
            string[] R = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                HashSet<string> str = Generate(X);
                bool[] b = new bool[str.Count];
                Array.Resize(ref R, str.Count);
                for (int i = 0; i < str.Count; i++)
                {
                    if (R.Contains(str.ElementAt(i)))
                    {
                        b[i] = true;
                    }
                    else
                        b[i] = false;
                }

                Console.WriteLine();
                int count = 0;
                bool[,] A = new bool[X.Length, X.Length];
                bool[,] C = new bool[N, N];
                for (int i = 0; i < X.Length; i++)
                {
                    for (int j = 0; j < X.Length; j++)
                    {
                        A[i, j] = b[count];
                        count++;
                        if (j % X.Length == 0 && j > 0)
                        {
                            i++;
                        }
                    }
                }

                for (int i = 0; i < X.Length; i++)
                {
                    for (int j = 0; j < X.Length; j++)
                    {
                        if (A[i, j] == true)
                        {
                            C[i, j] = true;
                            Console.Write(1 + " ");
                        }
                        else
                        {
                            C[i, j] = false;
                            Console.Write(0 + " ");
                        }
                    }
                    Console.WriteLine();
                }

                //реализация алгоритма
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        for (int k = 0; k < N; k++)
                        {
                            C[i, j] = C[i, j] || (C[i, k] && C[k, j]);
                        }
                    }
                }
                Console.WriteLine("Матрица транзитивного замыкания отношения R:");

                for (int i = 0; i < X.Length; i++)
                {
                    for (int j = 0; j < X.Length; j++)
                    {
                        if (C[i, j] == true)
                        {
                            Console.Write(1 + " ");
                        }
                        else
                            Console.Write(0 + " ");
                    }
                    Console.WriteLine();
                }
            Console.WriteLine("Множество пар транзитивного замыкания:");
            HashSet<string> result = new HashSet<string>();
            string s="";
            for (int i = 0; i < X.Length; i++)
            {
                for (int j = 0; j < X.Length; j++)
                {
                    if (C[i, j] == true)
                    {
                        s = "(" + X.ElementAt(i)+","+ X.ElementAt(j) + ")";
                    }
                    result.Add(s);
                }
            }
            foreach (string t in result)
            {
                Console.Write(t + " ");
            }
            Console.WriteLine();
        }

    }
}

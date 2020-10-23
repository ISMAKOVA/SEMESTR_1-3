using System;
using System.Collections.Generic;
using System.Linq;

namespace task2._KM
{
    class MainClass
    {
       // int check_or = 0;
        public static bool[,] enterB(string[] X)
        {
            Console.WriteLine("Введите отношение:");
            int n = X.Length;
            int[,] arr = new int[n, n];
            string[] r = new string[n];
            bool[,] b = new bool[n, n];
            for(int i = 0; i < r.Length; i++)
            {
                r= Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                for(int j = 0; j < n; j++)
                {
                     arr[i, j] = Int32.Parse(r[j]);
                }
            }
            Console.WriteLine("Булева матрица: ");

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (arr[i, j] == 1)
                    {
                        b[i, j] = true;
                        Console.Write(1 + " ");
                    }
                    else
                    {
                        b[i, j] = false;
                        Console.Write(0 + " ");
                    }
                }
                Console.WriteLine();
            }
            return b;
        }
        public static bool[,] enterM(string[] X)
        {
            Console.WriteLine("Введите отношение R множеством пар:");
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
            Console.WriteLine("Булева матрица: ");

            int count = 0;
            bool[,] BoolM = new bool[X.Length, X.Length];
            for (int i = 0; i < X.Length; i++)
            {
                for (int j = 0; j < X.Length; j++)
                {
                    BoolM[i, j] = b[count];
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
                    if (BoolM[i, j] == true)
                    {
                        Console.Write(1 + " ");
                    }
                    else
                        Console.Write(0 + " ");
                }
                Console.WriteLine();
            }
            return BoolM;
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

        public static void Hash(String[] S, HashSet<string> A)
        {
            for (int k = 0; k < S.Length; k++)
            {
                A.Add(S[k]);
            }
        }

        public static bool Reflexivity(bool[,] b, string[] X)
        {
            bool a = false;
            int counter = 0;
            for (int i = 0; i < X.Length; i++)
            {
                if (b[i, i] == true)
                {
                    counter++;
                    a = true;
                }
                else a = false;
                if (counter != X.Length)
                {
                    a = false;
                }
            }
            return a;
        }
        static bool AntiRef(bool[,] b, string[] X)
        {
            bool a = false;
            int counter = 0;
            for (int i = 0; i < X.Length; i++)
            {
                if (b[i, i] == false)
                {
                    counter++;
                    a = true;
                }
                else a = false;
                if (counter != X.Length)
                {
                    a = false;
                }
            }
            return a;
        }
        static void Symmetry(bool[,] b, string[] X)
        {
            int counter = 0;
            for (int i = 0; i < X.Length; i++)
            {
                for (int j = 0; j < X.Length; j++)
                {
                    if (b[j, i] && b[i, j])
                    {
                        counter++;
                    }
                }
            }
            if (counter >= 1) { 
            Console.WriteLine("Симметричность: да"); }
            else Console.WriteLine("Симметричность: нет");
        }

         public static void AntiSym(bool[,] b, string[] X)
        {
            int counter = 0;
            for (int i = 0; i < X.Length; i++)
            {
                for (int j = 0; j < X.Length; j++)
                {
                    if (b[j, i] && !b[i, j])
                    {
                        counter++;
                    }
                }
            }
            if (counter >= 1) { Console.WriteLine("Антисимметричность: да");}
            else Console.WriteLine("Антисимметричность: нет");
        }
        static void Lin(bool[,] b, string[] X)
        {
            bool a = false;
            int counter = 0;
            int n = X.Length * X.Length;
            for (int i = 0; i < X.Length; i++)
            {
                for (int j = 0; j < X.Length; j++)
                {
                    // if ((b[j, i] != b[i, j]) && (b[j, i] && b[i, j]) || (b[i, j] && b[j, i]))
                    if (b[i, j]==true)
                    {
                        counter++;
                        if (counter == n)
                        {
                            a = true;
                        }
                        else a = false;
                    }
                    else a = false;
                }
            }
            if (a == true)
            {
                Console.WriteLine("Полнота: да");
            }
            else { Console.WriteLine("Полнота: нет"); }
        }

        static void Transit(bool[,] b, string[] X)
        {
            int counter = 0;
            for (int i = 0; i < b.GetLength(0); i++)
            {
                for (int j = 0; j < b.GetLength(0); j++)
                {
                    if (b[i, j])
                    {
                        for (int k = 0; k < b.GetLength(0); k++)
                        {
                            if (b[j, k] && b[i, k])
                            {
                                counter++;
                            }
                        }
                    }
                }
            }

            if (counter >= 1)
            {
                Console.WriteLine("Транзитивность: да");
            }
            else
                Console.WriteLine("Транзитивность: нет");
        }

        public static void Equiv(bool[,] b, string[] X)
        {
            int counter = 0;
            bool a = false;
            for (int i = 0; i < X.Length; i++)
            {
                for (int j = 0; j < X.Length; j++)
                {
                    if (b[i, i])
                    {
                        if (b[j, i] && b[i, j])
                        {
                            if (b[i, j])
                            {
                                for (int k = 0; k < b.GetLength(0); k++)
                                {
                                    if (b[j, k] && b[i, k])
                                    {
                                        counter++;
                                        a = true;
                                    }
                                }
                            }
                        }
                    }
                    else a = false;
                }
                
            }
            if (a)
            {
                Console.WriteLine("Эквивалентность: да");
            }
            else
            {
                Console.WriteLine("Эквивалентность: нет");
            }
        }

        public static void PartLin(bool[,] b, string[] X)
        {
            int counter = 0;
            //bool a = false;
            for (int i = 0; i < X.Length; i++)
            {
                for (int j = 0; j < X.Length; j++)
                {
                        if (b[j, i] && !b[i, j])
                        {
                            for (int k = 0; k < X.Length; k++)
                            {
                                if (b[j, k] && b[i, k])
                                {
                                    counter++;
                                }
                            }
                        }
                }

            }
            if (counter >= 1)
            {
                Console.WriteLine("Отношения порядка: да");
            }
            else
            {
                Console.WriteLine("Отношения порядка: нет");
            }
        }
        public static void Main(string[] args)
        {
            Console.WriteLine("Введите множество Х:");
            string[] M = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            HashSet<string> U = new HashSet<string>();
            Hash(M, U);//избавляемся от повторений
            string[] X = new string[0];
            for (int i = 0; i < U.Count; i++)
            {
                Array.Resize(ref X, X.Length + 1);
                X[i] = U.ElementAt(i);
            }
            Console.WriteLine("Множество пар множества Х:");
            foreach (string t in Generate(X))
            {
                Console.Write(t + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Выберете формат ввода: булева матрица(1) или множество пар(2)");
            int num = Int32.Parse(Console.ReadLine());
            switch (num)
            {
                case 1:
                    bool[,] BoolB = enterB(X);
                    Console.Write("Рефлексивность: ");
                    Console.WriteLine(Reflexivity(BoolB, X) ? "да" : "нет");
                    Console.Write("Антирефлексивность: ");
                    Console.WriteLine(AntiRef(BoolB, X) ? "да" : "нет");
                    Symmetry(BoolB, X);
                    AntiSym(BoolB, X);
                    Lin(BoolB, X);
                    Transit(BoolB, X);
                    Equiv(BoolB, X);
                    PartLin(BoolB, X);
                    break;
                case 2:
                    bool[,] BoolM = enterM(X);
                    Console.Write("Рефлексивность: ");
                    Console.WriteLine(Reflexivity(BoolM, X) ? "да" : "нет");
                    Console.Write("Антирефлексивность: ");
                    Console.WriteLine(AntiRef(BoolM, X) ? "да" : "нет");
                    Symmetry(BoolM, X);
                    AntiSym(BoolM, X);
                    Lin(BoolM, X);
                    Transit(BoolM, X);
                    Equiv(BoolM, X);
                    PartLin(BoolM, X);
                    break;
                 default:
                    Console.WriteLine("Проверьте правильность числа");
                    break;
            }
        }
    }
}



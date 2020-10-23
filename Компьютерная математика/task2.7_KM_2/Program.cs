using System;
using System.Collections.Generic;
using System.Linq;
using TaskLibrary;
namespace task2._KM_2
{
    class MainClass
    {

        //ввод множества пар


        public static void Main(string[] args)
        {
            int counter = 0;
            int count_t = 0;
            int equiv = 0;
            int partLin = 0;
            int fullness = 0;

            Console.WriteLine("Введите множество Х:");
            string[] M = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            HashSet<string> U = new HashSet<string>();
            Methods.Hash(M, U);//избавляемся от повторений
            string[] X = new string[0];
            for (int i = 0; i < U.Count; i++)
            {
                Array.Resize(ref X, X.Length + 1);
                X[i] = U.ElementAt(i);
            }
            Console.WriteLine("Множество пар множества Х:");
            foreach (string t in Methods.CartesianProduct(X))
            {
                Console.Write(t + " ");
            }
            Console.WriteLine();

            //создаем массив false
            bool[,] b = new bool[X.Length, X.Length];
            for(int i = 0; i < X.Length; i++)
            {
                for(int j = 0; j < X.Length; j++)
                {
                    b[i, j] = false;
                }
            }

            Console.WriteLine("Выберете формат ввода: булева матрица(1) или множество пар(2)");
            int num = Int32.Parse(Console.ReadLine());
            switch (num)
            {
                case 1:
                m1:
                    Console.WriteLine($"Введите отношение в формате {X.Length} x {X.Length}:");
                    int n = X.Length;
                    int[,] arr = new int[n, n];
                    string[] r = new string[n];
                    for (int i = 0; i < r.Length; i++)
                    {
                       
                        r = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                        for (int j = 0; j < n; j++)
                        {
                            try { arr[i, j] = Int32.Parse(r[j]); }
                            catch
                            { 
                            Console.WriteLine($"Ввод не соответствует формату {X.Length} x {X.Length}");
                            goto m1;
                            }
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
                                count_t++;
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
                    break;
                case 2:
                    Console.WriteLine("Введите отношение R множеством пар:");
                    string[] R = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    HashSet<string> str = Methods.CartesianProduct(X);
                    bool[] bs = new bool[str.Count];
                    Array.Resize(ref R, str.Count);

                    for (int i = 0; i < str.Count; i++)
                    {
                        if (R.Contains(str.ElementAt(i)))
                        {
                            bs[i] = true;
                            count_t++;
                        }
                        else
                            bs[i] = false;
                    }
                    Console.WriteLine("Булева матрица: ");

                    int count = 0;
                    for (int i = 0; i < X.Length; i++)
                    {
                        for (int j = 0; j < X.Length; j++)
                        {
                            b[i, j] = bs[count];
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
                            if (b[i, j] == true)
                            {
                                Console.Write(1 + " ");
                            }
                            else
                                Console.Write(0 + " ");
                        }
                        Console.WriteLine();
                    }

                    break;
                default:
                    Console.WriteLine("Проверьте правильность числа");
                    break;
            }

            //рефлексивность

            bool iskl = false;
            counter = 0;
            for(int i = 0; i < X.Length; i++)
            {
                if (b[i, i])
                {
                    counter++;
                }
            }
            if (counter == X.Length)
            {
                equiv++;
                iskl = true;
                Console.WriteLine("Рефлексивность: да");
            }
            else if (counter != X.Length)
            {
                Console.WriteLine("Рефлексивность: нет");
            }

            //антирефлексивность

            counter = 0;
            for (int i = 0; i < X.Length; i++)
            {
                if (b[i, i]==false)
                {
                    counter++;
                }
            }
            if (counter == X.Length)
            {
                Console.WriteLine("Антирефлексивность: да");
            }
            else if (counter != X.Length)
            {
                Console.WriteLine("Антирефлексивность: нет");
            }

            //симметиричность 

            bool check = false;
            for (int i = 0; i < X.Length; i++)
            {
                for (int j = 0; j < X.Length; j++)
                {
                    if (i != j)
                    {
                       if (b[j, i] && !b[i, j])
                        {
                            check = true;
                            break;
                        }
                    }
                }
            }
            if (check==false)
            {
                equiv++;
                Console.WriteLine("Симметричность: да");
            }
            else Console.WriteLine("Симметричность: нет");

            //антисимметиричность 


            counter = 0;
            for (int i = 0; i < X.Length; i++)
            {
                for (int j = 0; j < X.Length; j++)
                {
                    if (i != j)
                    {
                        if (b[i, j] && !b[j, i])
                        {
                            counter++;
                        }
                    }

                }
            }
             if(counter >= 1)
            {
                partLin++;
                fullness++;
                Console.WriteLine("Антисимметричность: да");
            }
            else  Console.WriteLine("Антисимметричность: нет");

            //транзитивность

             counter = 0;
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
            if (iskl == true && count_t == X.Length) { Console.WriteLine("Транзитивность: нет"); }
            else if (counter >= 1)
            {
                equiv++;
                partLin++;
                fullness++;
                Console.WriteLine("Транзитивность: да");
            }
            else
                Console.WriteLine("Транзитивность: нет");

            //полнота

            check = false;
            for (int i = 0; i < X.Length; i++)
            {
                for (int j = 0; j < X.Length; j++)
                {
                    if (b[i, j] == false)
                    {
                        check = true;
                        break;
                    }
                }
            }
            if ( check == false)
            {
                fullness++;
                Console.WriteLine("Полнота: да");
            }
            else Console.WriteLine("Полнота: нет");

            if (equiv == 3)
            {
                Console.WriteLine("Эквивалентность:да");
            }
            else Console.WriteLine("Эквивалентность:нет");

            if (partLin == 2)
            {
                Console.WriteLine("Отношение частичного порядка: да");
            }
            else Console.WriteLine("Отношение частичного порядка: нет");

            if (fullness == 3)
            {
                Console.WriteLine("Отношение полного порядка: да");
            }
            else Console.WriteLine("Отношение полного порядка: нет");

            Console.ReadKey();
        }

        



    }
}

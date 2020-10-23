using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace labaKM
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //1 задание
            // task1();

            //2 задание
            // task2();
            //3 задание
            //task3();

            //задание 5

            HashSet<string> U = new HashSet<string>();
            Console.WriteLine("Введите элементы универсума");
            string[] strU = Console.ReadLine().Split(new char[] { ' ', '\n', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < strU.Length; i++)
            {
                U.Add(strU[i]);//добавляем в коллекцию 
            }
            string[] resultU = U.Distinct().ToArray();

            HashSet<string> A = new HashSet<string>();
            HashSet<string> B = new HashSet<string>();
            Console.WriteLine("Введите элементы множества А");
            string[] strA = Console.ReadLine().Split(new char[] { ' ', '\n', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < strA.Length; i++)
            {
                A.Add(strA[i]);//добавляем в коллекцию 
            }
            string[] resultA = A.Distinct().ToArray();
            for (int i = 0; i < resultA.Length; i++)
            {
                if (U.Contains(resultA[i]))
                {
                    A.Add(resultA[i]);
                }
                else
                {
                    A.Remove(resultA[i]);
                    Console.WriteLine("{0} не входит в U", resultA[i]);
                }
            }
            Console.WriteLine("Готовое множество A");

            foreach (string a in A)
            {
                Console.WriteLine(a);
            }

            Console.WriteLine("Введите элементы множества B");
            string[] strB = Console.ReadLine().Split(new char[] { ' ', '\n', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < strB.Length; i++)
            {
                B.Add(strB[i]);//добавляем в коллекцию 
            }
            string[] resultB = B.Distinct().ToArray();
            for (int i = 0; i < resultB.Length; i++)
            {
                if (U.Contains(resultB[i]))
                {
                    B.Add(resultB[i]);
                }
                else
                {
                    B.Remove(resultB[i]);
                    Console.WriteLine("{0} не входит в U", resultB[i]);
                }
            }
            Console.WriteLine("Готовое множество B");

            foreach (string a in B)
            {
                Console.WriteLine(a);
            }
            HashSet<string> one = getUnion(A, B);
            HashSet<string> two = getIntersect(A, B);
            HashSet<string> three = getExcept(A, B);
            HashSet<string> four = getExcept(U, A);
            Console.WriteLine("Объединение");
            foreach(string a in one)
            {
                Console.WriteLine(a);
            }
            Console.WriteLine("Пересечение");
            foreach (string a in two)
            {
                Console.WriteLine(a);
            }
            Console.WriteLine("Разность");
            foreach (string a in three)
            {
                Console.WriteLine(a);
            }
            Console.WriteLine("Дополнение до А");
            foreach (string a in four)
            {
                Console.WriteLine(a);
            }

            Console.WriteLine("Выберите задание: 1, 2 или 3");
            string n = Console.ReadLine();
            switch (n)
            {
                case "1":
                    getFirstEl();
                    break;
                case "2":
                    getSecondEl();
                    break;
                case "3":
                    getThirdEl();
                    break;
                default:
                    Console.WriteLine("Возможно вы ввели что-то не так");
                    break;
            }


            // 9 задание
            // task8();




        }
        //  public static void task2(/*мно-во из 1 задания*/){}
        public static void task1()
        {
            int n = 0;
            int[] x = new int[0];
            while (n < 7)
            {
                int f = n * n * n - 1;
                Array.Resize(ref x, x.Length + 1);
                x[n] = f;
                n++;
            }
            Console.Write("Множество 5 задание: ");
            for (int i = 0; i < x.Length; i++)
            {
                Console.Write(x[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Его мощность:{0}", n);

        }

        public static void task2()
        {


        }

        public static void task3()
        {

            Console.WriteLine("Введите слово");
            HashSet<string> word = new HashSet<string>();
            char[] lett1 = Console.ReadLine().ToCharArray();

            for (int i = 0; i < lett1.Length; i++)
            {
                word.Add(lett1[i].ToString());
            }
            Console.WriteLine("Готовое множество");
            string[] result = word.Distinct().ToArray();
            foreach (string a in result)
            {
                Console.WriteLine(a);
            }


        }

        public static void task9()
        {
            Console.WriteLine("Введите мощность множества:");
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];

            Console.WriteLine("Введите значения множества:");

            string[] str = Console.ReadLine().Split(new char[] { ' ', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < n; i++)
            {
                arr[i] = Convert.ToInt32(str[i]);
            }

            int k = Convert.ToInt32(Math.Pow(2, Convert.ToDouble(n)));
            string[] combs = new string[k];

            for (int i = 0; i < combs.Length; i++)
            {
                combs[i] = Convert.ToString(i, 2);
                combs[i] = combs[i].PadLeft(n, '0');
            }
            Console.WriteLine("{0}");
            for (int i = 0; i < combs.Length; i++)
            {
                char[] a = combs[i].ToCharArray();
                for (int j = 0; j < a.Length; j++)
                {
                    if (a[j] == '1') Console.Write(arr[j] + " ");
                }
                Console.WriteLine();
            }
        }

        public static void getFirstEl()
        {
            HashSet<string> U = new HashSet<string>();
            Console.WriteLine("Введите элементы универсума");
            string[] strU = Console.ReadLine().Split(new char[] { ' ', '\n', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < strU.Length; i++)
            {
                U.Add(strU[i]);//добавляем в коллекцию 
            }
            string[] resultU = U.Distinct().ToArray();

            HashSet<string> A = new HashSet<string>();
            HashSet<string> B = new HashSet<string>();
            Console.WriteLine("Введите элементы множества А");
            string[] strA = Console.ReadLine().Split(new char[] { ' ', '\n', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < strA.Length; i++)
            {
                A.Add(strA[i]);//добавляем в коллекцию 
            }
            string[] resultA = A.Distinct().ToArray();
            for (int i = 0; i < resultA.Length; i++)
            {
                if (U.Contains(resultA[i]))
                {
                    A.Add(resultA[i]);
                }
                else
                {
                    A.Remove(resultA[i]);
                    Console.WriteLine("{0} не входит в U", resultA[i]);
                }
            }
            Console.WriteLine("Готовое множество A");

            foreach (string a in A)
            {
                Console.WriteLine(a);
            }

            Console.WriteLine("Введите элементы множества B");
            string[] strB = Console.ReadLine().Split(new char[] { ' ', '\n', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < strB.Length; i++)
            {
                B.Add(strB[i]);//добавляем в коллекцию 
            }
            string[] resultB = B.Distinct().ToArray();
            for (int i = 0; i < resultB.Length; i++)
            {
                if (U.Contains(resultB[i]))
                {
                    B.Add(resultB[i]);
                }
                else
                {
                    B.Remove(resultB[i]);
                    Console.WriteLine("{0} не входит в U", resultB[i]);
                }
            }
            Console.WriteLine("Готовое множество B");

            foreach (string a in B)
            {
                Console.WriteLine(a);
            }
            Console.WriteLine("Решение №1:");
            HashSet<string> t = getUnion(getIntersect(A, B), getIntersect(A, getExcept(U, B)));
            HashSet<string> tt = getUnion(t, getIntersect(getExcept(U, A), B));
            foreach (string u in tt)
            {
                Console.WriteLine(u);
            }



        }

        public static void getSecondEl()
        {
            HashSet<string> U = new HashSet<string>();
            Console.WriteLine("Введите элементы универсума");
            string[] strU = Console.ReadLine().Split(new char[] { ' ', '\n', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < strU.Length; i++)
            {
                U.Add(strU[i]);//добавляем в коллекцию 
            }
            string[] resultU = U.Distinct().ToArray();
            HashSet<string> A = new HashSet<string>();
            HashSet<string> B = new HashSet<string>();
            Console.WriteLine("Введите элементы множества А");
            string[] strA = Console.ReadLine().Split(new char[] { ' ', '\n', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < strA.Length; i++)
            {
                A.Add(strA[i]);//добавляем в коллекцию 
            }
            string[] resultA = A.Distinct().ToArray();
            for (int i = 0; i < resultA.Length; i++)
            {
                if (U.Contains(resultA[i]))
                {
                    A.Add(resultA[i]);
                }
                else
                {
                    A.Remove(resultA[i]);
                    Console.WriteLine("{0} не входит в U", resultA[i]);
                }
            }
            Console.WriteLine("Готовое множество A");

            foreach (string a in A)
            {
                Console.WriteLine(a);
            }

            Console.WriteLine("Введите элементы множества B");
            string[] strB = Console.ReadLine().Split(new char[] { ' ', '\n', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < strB.Length; i++)
            {
                B.Add(strB[i]);//добавляем в коллекцию 
            }
            string[] resultB = B.Distinct().ToArray();
            for (int i = 0; i < resultB.Length; i++)
            {
                if (U.Contains(resultB[i]))
                {
                    B.Add(resultB[i]);
                }
                else
                {
                    B.Remove(resultB[i]);
                    Console.WriteLine("{0} не входит в U", resultB[i]);
                }
            }
            Console.WriteLine("Готовое множество B");

            foreach (string a in B)
            {
                Console.WriteLine(a);
            }

            HashSet<string> t1 = getUnion(getExcept(U, B), getExcept(U, A));
            HashSet<string> t2 = getUnion(getExcept(U, B), A);
            HashSet<string> t3 = getIntersect(A, t1);
            HashSet<string> t4 = getIntersect(t2, B);
            HashSet<string> total = getExcept(U, getIntersect(t3, t4));
            Console.WriteLine("Решение №2:");
            foreach (string t in total)
            {
                Console.WriteLine(t);
            }
        }
        public static void getThirdEl()
        {
            HashSet<string> U = new HashSet<string>();
            Console.WriteLine("Введите элементы универсума");
            string[] strU = Console.ReadLine().Split(new char[] { ' ', '\n', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < strU.Length; i++)
            {
                U.Add(strU[i]);//добавляем в коллекцию 
            }
            string[] resultU = U.Distinct().ToArray();
            HashSet<string> A = new HashSet<string>();
            HashSet<string> B = new HashSet<string>();
            HashSet<string> C = new HashSet<string>();
            Console.WriteLine("Введите элементы множества А");
            string[] strA = Console.ReadLine().Split(new char[] { ' ', '\n', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < strA.Length; i++)
            {
                A.Add(strA[i]);//добавляем в коллекцию 
            }
            string[] resultA = A.Distinct().ToArray();
            for (int i = 0; i < resultA.Length; i++)
            {
                if (U.Contains(resultA[i]))
                {
                    A.Add(resultA[i]);
                }
                else
                {
                    A.Remove(resultA[i]);
                    Console.WriteLine("{0} не входит в U", resultA[i]);
                }
            }
            Console.WriteLine("Готовое множество A");

            foreach (string a in A)
            {
                Console.WriteLine(a);
            }

            Console.WriteLine("Введите элементы множества B");
            string[] strB = Console.ReadLine().Split(new char[] { ' ', '\n', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < strB.Length; i++)
            {
                B.Add(strB[i]);//добавляем в коллекцию 
            }
            string[] resultB = B.Distinct().ToArray();
            for (int i = 0; i < resultB.Length; i++)
            {
                if (U.Contains(resultB[i]))
                {
                    B.Add(resultB[i]);
                }
                else
                {
                    B.Remove(resultB[i]);
                    Console.WriteLine("{0} не входит в U", resultB[i]);
                }
            }
            Console.WriteLine("Готовое множество B");

            foreach (string a in B)
            {
                Console.WriteLine(a);
            }

            Console.WriteLine("Введите элементы множества C");
            string[] strC = Console.ReadLine().Split(new char[] { ' ', '\n', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < strC.Length; i++)
            {
                C.Add(strC[i]);//добавляем в коллекцию 
            }
            string[] resultC = C.Distinct().ToArray();
            for (int i = 0; i < resultC.Length; i++)
            {
                if (U.Contains(resultC[i]))
                {
                    C.Add(resultC[i]);
                }
                else
                {
                    C.Remove(resultC[i]);
                    Console.WriteLine("{0} не входит в U", resultC[i]);
                }
            }
            Console.WriteLine("Готовое множество C");

            foreach (string a in C)
            {
                Console.WriteLine(a);
            }
            HashSet<string> t1 = getUnion(getUnion(getExcept(U, A), B), C);
            HashSet<string> t2 = getUnion(A, B);
            HashSet<string> total = getExcept(t1, t2);
            Console.WriteLine("Результат №3:");
            foreach (string t in total)
            {
                Console.WriteLine(t);
            }

        }
        //метод для объединения
        public static HashSet<string> getUnion(HashSet<string> A, HashSet<string> B)
        {
            HashSet<string> union = new HashSet<string>(A.Union(B));
            return union;
        }
        //метод для пересечения
        public static HashSet<string> getIntersect(HashSet<string> A, HashSet<string> B)
        {
            HashSet<string> intersect = new HashSet<string>(A.Intersect(B));
            return intersect;
        }
        //метод для дополнения|разности
        public static HashSet<string> getExcept(HashSet<string> A, HashSet<string> B)
        {
            HashSet<string> except = new HashSet<string>(A.Except(B));
            return except;
        }



    }
    }



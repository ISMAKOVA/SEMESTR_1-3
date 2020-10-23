using System;
using System.Linq;
using System.Collections.Generic;
namespace KM_02
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //2.1 задание
             //task1();
            task2();




        }
        public static void task1()
        {
            //2.1 задание
            HashSet<string> A1 = new HashSet<string>();
            HashSet<string> B1 = new HashSet<string>();

            Console.WriteLine("Введите множество А");
            string[] A = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < A.Length; i++)
            {
                A1.Add(A[i]);//добавляем в коллекцию 
            }
            string[] resultA = A.Distinct().ToArray();
            Console.WriteLine("множество A");
            foreach (string s in resultA)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine("Введите множество В");
            string[] B = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < B.Length; i++)
            {
                B1.Add(B[i]);//добавляем в коллекцию 
            }
            string[] resultB = B.Distinct().ToArray();
            Console.WriteLine("множество В");
            foreach(string s in resultB)
            {
                Console.WriteLine(s);
            }

            string[] arrTotal = new string[0];
            for (int i = 0; i < resultA.Length; i++)
            {
                for (int j = 0; j < resultB.Length; j++)
                {
                    Array.Resize(ref arrTotal, arrTotal.Length + 1);
                    arrTotal[i] = "(" + resultA[i] + "," + resultB[j] + ")";
                    Console.Write(arrTotal[i]);
                }
            }
            Console.WriteLine();
        }
        public static void task2()
        {
            //2.2 задание 
            bool n=true;
            while (n==true) { 
            HashSet<string> A = new HashSet<string>();
            HashSet<string> B = new HashSet<string>();
            string[] ch=new string[0];
            Console.WriteLine("Введите декартово произведение");
            string[] M = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string[] multipl = new string[0];

                if (multipl.Length % 2 != 0)
                {
                    Console.WriteLine("Проверьте правильность ввода");
                }
                else
                {
                    Console.WriteLine();

                    for (int i = 0; i < M.Length; i++)
                    {
                        Array.Resize(ref multipl, multipl.Length + 1);
                        multipl = M[i].Split(new char[] { ',', '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
                        for (int j = 0; j < multipl.Length; j++)
                        {
                            if (j % 2 == 0) A.Add(multipl[j]);
                            else B.Add(multipl[j]);
                        }
                    }


                    if (A.Count * B.Count != M.Length || multipl.Length!=2)
                    {
                        Console.WriteLine("Проверьте правильность ввода");
                    }
                    else
                    {
                        Console.WriteLine($"A = {string.Join(" ", A)}");
                        Console.WriteLine($"B = {string.Join(" ", B)}");
                        n = false;
                    }
                }
            }
        }
    }
}

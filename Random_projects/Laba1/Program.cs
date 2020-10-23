using System;
using System.Collections.Generic;
using System.Linq;

namespace Laba1
{
    class MainClass
    {
        int n = 0;
        int[] x = new int[0];
        public static void Main(string[] args,int n, int[] x)
        {
            //5 вариант
            //1 задание
           
             while (n < 7)
             {
                 int f = n * n * n - 1;
                 Array.Resize(ref x, x.Length + 1);
                 x[n] = f;
                 n++;
             }
             Console.Write("Множество 5 задание: ");
             for (int i = 0; i < x.Length; i++)
                 Console.Write(x[i] + " ");
             Console.WriteLine();
             Console.WriteLine("Его мощность:{0}", n);






            Console.WriteLine("Введите множество");
            string numbers = Console.ReadLine();
            char[] det = { ' ', ' '};









            /*   Console.WriteLine("3 задание");

               //3 задание
               Console.WriteLine("Введите слово:");
                string word = Console.ReadLine();
                List<char> letters = new List<char>() { '\0' };
               foreach(char t in word)
                {
                    int i = 0;
                    while(letters[i]!='\0' && letters[i] != t)
                    {
                        i = i * 2 + (t < letters[i] ? 1 : 2);
                        while (letters.Count <= i) letters.Add('\0');
                    }
                    letters[i] = t;
                }
               foreach(char t in letters)
                {
                    if (t != '\0') Console.WriteLine(t);
                }
               Console.WriteLine("5 задание");
               */
            task5();



            Console.ReadKey();
             

        }
         public static void task5()
        {
            //5 задание
            Console.WriteLine("Введите длину первого множества");
            int n1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите первое множество");
            int [] arr1 = new int[0];
            for(int i =0; i < n1; i++)
            {
                Array.Resize(ref arr1, arr1.Length + 1);
                arr1[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Введите длину второго множества");
            int n2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите второе множество");
            int[] arr2 = new int[0];
            for (int i = 0; i < n2; i++)
            {
                Array.Resize(ref arr2, arr2.Length + 1);
               arr2[i] = int.Parse(Console.ReadLine());
            }

            IEnumerable<int> union = arr1.Union(arr2);
            Console.WriteLine("Операция объединение:");
            foreach (int num in union)
            {
                Console.Write("{0} ",num);
            }

            IEnumerable<int> intersect = arr1.Intersect(arr2);
            Console.WriteLine("\nОперация пересечение:");
            foreach (int num in intersect)
            {
                Console.Write("{0} ", num);
            }

            IEnumerable<int> except = arr1.Except(arr2);
            Console.WriteLine("\nОперация разности:");
            foreach (int num in except)
            {
                Console.Write("{0} ", num);
            }

            Console.WriteLine("\nКол-во элементов универсального мн-ва");
            int n3 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите универсальное множество");
            int[] arr3 = new int[0];
            for (int i = 0; i < n3; i++)
            {
                Array.Resize(ref arr3, arr3.Length + 1);
                arr3[i] = int.Parse(Console.ReadLine());
            }

            IEnumerable<int> except3 = arr3.Except(arr1);
            Console.WriteLine("\nОперация дополнения до заданного универсума первого мн-ва:");
            foreach (int num in except3)
            {
                Console.Write("{0} ", num);
            }

            IEnumerable<int> except4 = arr3.Except(arr2);
            Console.WriteLine("\nОперация дополнения до заданного универсума второго мн-ва:");
            foreach (int num in except4)
            {
                Console.Write("{0} ", num);
            }
        }
        public static void  getSmth(  )
        {

        }

    }
}


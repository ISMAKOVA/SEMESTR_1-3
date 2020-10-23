using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ismakova
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int[] arr = { -1, -2, -3, -4, 1, 2, 3, 4, 5 };
            int[] arr2 = { 1, 1, 4, 2, 1, 3 };

            GetAverage(arr);
            FindCopy(arr2);
           //Console.WriteLine( HeightChecker(arr2).ToString());
            Console.ReadKey();
        }

        public static void GetAverage(int [] arr)
        {
            int count = 0;
            int aver = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] >= 0)
                {
                    count++;
                    aver += arr[i];
                }

            }
            if (aver != 0 && count != 0)
                Console.WriteLine(aver / count);
        }
        public static int HeightChecker(int [] arr)
        {
            int n=0;

            for(int i = 0; i < arr.Length; i++)
            {
                for(int j = 0; j < arr.Length; j++)
                {
                    if (arr[i] > arr[j])
                    {
                        int term = arr[i];
                        arr[i] = arr[j];
                        arr[j] = term;
                        n++;
                    }
                      
                }
            }

 
            return n;
        }
        public static void FindCopy(int [] arr)
        {
            HashSet<int> set = new HashSet<int>();
            foreach(int n in arr)
            {
                if (!set.Add(n))
                    Console.Write(n + " ");
            }


        }
    }
}

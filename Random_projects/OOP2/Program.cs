using System;

namespace OOP2
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int x = 6;
            bool n = false;
            int[] arr = { 1, 2, 3, 4, 5, 6, 7 };
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length; j++)
                {
                    if ((arr[i] + arr[j]) == x && i != j)
                        Console.WriteLine(arr[i] + " " + arr[j]);
                        n = true;
                }
            }
            Console.WriteLine(n);
            Console.WriteLine("____________");
            isContains(arr, x);

           
        }
        public static void isContains(int  [] arr, int x)
        {
            Array.Sort(arr);
            int first = 0;
            int last = arr.Length-1;

            while (first < last)
            {
                if (arr[first] + arr[last] == x)
                {
                    Console.WriteLine(arr[first] + " " + arr[last]);
                    first++;
                    last--;
                }
                else if (arr[first] + arr[last] < x) first++;
                else last--;
            }

        }

       

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[10];
            int[] arr2 = new int[10];
            int[] arr3 = new int[10];
            Random rnd = new Random();
            for(int i=0;i< arr.Length;i++)
            {
                arr[i] = rnd.Next(0, 200);
                arr2[i] = rnd.Next(0, 200);
                arr3[i] = rnd.Next(0, 200);
            }
            Console.WriteLine("-----------------QuickSort---------------------");
            foreach (int n in arr)
            {
                Console.Write(n + " ");
            }
            Console.WriteLine();
            QuickSort(arr);
            foreach (int n in arr)
            {
                Console.Write(n + " ");
            }
            Console.WriteLine();
            Console.WriteLine("-----------------MergeSort----------------------");
            foreach (int n in arr2)
            {
                Console.Write(n + " ");
            }
            Console.WriteLine();
            MergeSort(arr2);
            foreach (int n in arr2)
            {
                Console.Write(n + " ");
            }
            Console.WriteLine();
            Console.WriteLine("-----------------GnomeSort---------------------");
            foreach (int n in arr3)
            {
                Console.Write(n + " ");
            }
            Console.WriteLine();
            GnomeSort(arr3);
            foreach (int n in arr3)
            {
                Console.Write(n + " ");
            }
            Console.WriteLine();
            Console.ReadLine();
        }
        //быстрая сортировка------------------------------
        public static int partition(int[] array, int start, int end)
        {
            int temp;
            int marker = start;
            for (int i = start; i < end; i++)
            {
                if (array[i] < array[end])
                {
                    temp = array[marker]; 
                    array[marker] = array[i];
                    array[i] = temp;
                    marker += 1;
                }
            }
            temp = array[marker];
            array[marker] = array[end];
            array[end] = temp;
            return marker;
        }

        public static void QuickSort(int[] array, int start, int end)
        {
            if (start >= end)
            {
                return;
            }
            int pivot = partition(array, start, end);
            QuickSort(array, start, pivot - 1);
            QuickSort(array, pivot + 1, end);
        }
        public static void QuickSort(int[] array)
        {
           QuickSort(array, 0, array.Length - 1);
        }

        //сортировка слиянием------------------------------
        static void Merge(int[] array, int lowIndex, int middleIndex, int highIndex)
        {
            var left = lowIndex;
            var right = middleIndex + 1;
            var tempArray = new int[highIndex - lowIndex + 1];
            var index = 0;

            while ((left <= middleIndex) && (right <= highIndex))
            {
                if (array[left] < array[right])
                {
                    tempArray[index] = array[left];
                    left++;
                }
                else
                {
                    tempArray[index] = array[right];
                    right++;
                }

                index++;
            }

            for (var i = left; i <= middleIndex; i++)
            {
                tempArray[index] = array[i];
                index++;
            }

            for (var i = right; i <= highIndex; i++)
            {
                tempArray[index] = array[i];
                index++;
            }

            for (var i = 0; i < tempArray.Length; i++)
            {
                array[lowIndex + i] = tempArray[i];
            }
        }

        //сортировка слиянием
        static int[] MergeSort(int[] array, int lowIndex, int highIndex)
        {
            if (lowIndex < highIndex)
            {
                var middleIndex = (lowIndex + highIndex) / 2;
                MergeSort(array, lowIndex, middleIndex);
                MergeSort(array, middleIndex + 1, highIndex);
                Merge(array, lowIndex, middleIndex, highIndex);
            }

            return array;
        }

        static int[] MergeSort(int[] array)
        {
            return MergeSort(array, 0, array.Length - 1);
        }


        public static void GnomeSort(int [] array)
        {
            int i = 1, tmp;
            while (i < array.Length)
                if (i == 0 || array[i - 1] <= array[i]) i++;
                else
                {
                    tmp = array[i];
                    array[i] = array[i - 1];
                    array[i - 1] = tmp;
                    i--;
                }
        }
    }
}

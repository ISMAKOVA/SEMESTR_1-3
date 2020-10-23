using System;

namespace factorial
{
    class MainClass
    {
        public static void Main(string[] args)
        { //1 часть
            Console.WriteLine("Введите число:");
            string s = Console.ReadLine();
            int n;
            if (Int32.TryParse(s, out n))
            {
                int f = 1;
                for (int i = 2; i <= n; i++)
                {
                    f = f * i;
                }
                Console.WriteLine("Факториал, выполненный в цикле");
                Console.WriteLine(f.ToString());
                Console.WriteLine("Факториал, выполненный с помощью рекурсии");
                Console.WriteLine(factoril(n));
            }
            else
            {
                Console.WriteLine("Проверьте правильность ввода");
            }
            BubleSort();
        }
        //2 часть
        public static int factoril(int n)
        {
            if (n == 0)
            {
                return 1;
            }
            else
            {
                return n * factoril(n - 1);
            }
        }

        public static void BubleSort()
        {
            Console.WriteLine("Сортировка пузырьком");
            Console.WriteLine("Введите числа:");
            string[] s = Console.ReadLine().Split(new char []{ ',',' '},StringSplitOptions.RemoveEmptyEntries);
            int[] arr = new int[0];
            for(int i = 0; i < s.Length; i++)
            {
                Array.Resize(ref arr, arr.Length + 1);
                arr[i] = Int32.Parse(s[i]);
            }
            int t;
            for(int i = 0; i < arr.Length; i++)
            {
                for(int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] > arr[j])
                    {
                        t = arr[i];
                        arr[i] = arr[j];
                        arr[j] = t;
                    }
                }
                Console.Write(arr[i].ToString() + " ");
            }
        }
    }
}

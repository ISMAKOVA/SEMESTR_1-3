﻿using System;

namespace hw
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int n = Int32.Parse(Console.ReadLine());
            int c = 2;
            int result = 1;
            int counter = 0;
            while (counter != n)
            {
                result *= c;
                counter++;
            }
            Console.WriteLine(result);
        }
        public static void task2()
        {
        }
    }
}

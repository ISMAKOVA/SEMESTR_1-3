using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using LogicalOperationsLibrary;
namespace task8_for_KM
{
    class MainClass
    {

        static void Main(string[] args)
        {
            var U = new HashSet<string>();
            var A = new HashSet<string>();
            var B = new HashSet<string>();

            Console.Write("Элементы множества U: ");
            string[] strU = Console.ReadLine().Split(new char[] { ' ', '\n', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries);
            Console.Write("Элементы множества U без повторений: ");
            Hash(strU, U);

            foreach (string el in U)
            {
                Console.Write(el + " ");
            }

            Console.Write("\nЭлементы множества A: ");
            string[] strA = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            Console.Write("Готовое множество A: ");
            Hash(strA, A);
            A.IntersectWith(U);
            foreach (string el in A)
            {
                Console.Write(el + " ");
            }

            Console.Write("\nЭлементы множества B: ");
            string[] strB = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            Console.Write("Готовое множество B : ");
            Hash(strB, B);
            B.IntersectWith(U);
            foreach (string el in B)
            {
                Console.Write(el + " ");
            }
            Array.Resize(ref strA, U.Count);
            Array.Resize(ref strB, U.Count);

            BitArray bitU = new BitArray(U.Count);
            BitArray bitA = new BitArray(strA.Length);
            BitArray bitB = new BitArray(strB.Length);

            update(bitU, bitA, U, strA);
            update(bitU, bitB, U, strB);

            BitArray or = LogicalOperations.Or(bitA, bitB);
            Console.Write("Объединение АВ: ");
            writeString(or, U);

            update(bitU, bitA, U, strA);
            update(bitU, bitB, U, strB);

            BitArray and = LogicalOperations.And(bitA, bitB);
            Console.Write("Пересечение АВ: ");
            writeString(and, U);

            update(bitU, bitA, U, strA);
            update(bitU, bitB, U, strB);

            BitArray not = LogicalOperations.Not(bitA);
            Console.Write("Дополнение А: ");
            writeString(not, U);

            update(bitU, bitA, U, strA);
            update(bitU, bitB, U, strB);


            BitArray diff = LogicalOperations.Dif(bitA, bitB);
            Console.Write("Разность А/В: ");
            writeString(diff, U);
            Console.WriteLine();

            bool con = false;
            Console.WriteLine("Пункт 2");
            while (con == false)
            {
                Console.WriteLine("Выберете задние 1,2 или 3");
                int n = Int32.Parse(Console.ReadLine());
                switch (n)
                {
                    case 1:
                        getFirst();
                        con = true;
                        break;
                    case 2:
                         getSecond();
                        con = true;
                        break;
                    case 3:
                         getThird();
                        con = true;
                        break;
                    default:
                        Console.WriteLine("Вы точно выбрали ту цифру?");
                        break;
                }
            }
        }
        public static void Hash(String[] S, HashSet<string> A)
        {
            for (int k = 0; k < S.Length; k++)
            {
                A.Add(S[k]);
            }
        }

        public static BitArray update(BitArray bitU, BitArray bitL, HashSet<string> U, string[] strL)
        {
            Console.WriteLine();
            bitU.SetAll(true);
            bitL.SetAll(false);

            for (int i = 0; i < U.Count; i++)
            {
                if (strL.Contains(U.ElementAt(i)))
                {
                    bitL[i] = true;
                }
                else
                {
                    bitL[i] = false;
                }

            }
            return bitL;
        }

        public static void writeString(BitArray a, HashSet<string> U)
        {
            for (int i = 0; i < U.Count; i++)
            {
                if (a[i] == true)
                {
                    foreach (char s in U.ElementAt(i))
                    {
                        Console.Write(s + " ");
                    }
                }
            }
        }



        public static void getFirst()
        {
            var U = new HashSet<string>();
            var A = new HashSet<string>();
            var B = new HashSet<string>();

            Console.Write("Элементы множества U: ");
            string[] strU = Console.ReadLine().Split(new char[] { ' ', '\n', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries);
            Console.Write("Элементы множества U без повторений: ");
            Hash(strU, U);

            foreach (string el in U)
            {
                Console.Write(el + " ");
            }

            Console.Write("\nЭлементы множества B: ");
            string[] strA = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            Console.Write("Готовое множество B: ");
            Hash(strA, A);
            A.IntersectWith(U);
            foreach (string el in A)
            {
                Console.Write(el + " ");
            }

            Console.Write("\nЭлементы множества C: ");
            string[] strB = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            Console.Write("Готовое множество C: ");
            Hash(strB, B);
            B.IntersectWith(U);
            foreach (string el in B)
            {
                Console.Write(el + " ");
            }
            Array.Resize(ref strA, U.Count);
            Array.Resize(ref strB, U.Count);

            BitArray bitU = new BitArray(U.Count);
            BitArray bitA = new BitArray(strA.Length);
            BitArray bitB = new BitArray(strB.Length);


            update(bitU, bitA, U, strA);
            update(bitU, bitB, U, strB);

           //BitArray two = Or(Or(And(bitA, bitB), And(bitA, Not(bitB))), Or(Not(bitA), bitB));
            //BitArray tt =Or(Or(And(bitA, bitB), And(bitA, Not(bitB))), And(Not(bitA),bitB));
            BitArray result = LogicalOperations.Or(bitA, bitB);

            writeString(result, U);
        }
        public static void getSecond()
        {
            HashSet<string> U = new HashSet<string>();
            HashSet<string> A = new HashSet<string>();
            HashSet<string> B = new HashSet<string>();

            Console.Write("Элементы множества U: ");
            string[] strU = Console.ReadLine().Split(new char[] { ' ', '\n', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries);
            Console.Write("Элементы множества U без повторений: ");
            Hash(strU, U);

            foreach (string el in U)
            {
                Console.Write(el + " ");
            }

            Console.Write("\nЭлементы множества A: ");
            string[] strA = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            Console.Write("Готовое множество A: ");
            Hash(strA, A);
            A.IntersectWith(U);
            foreach (string el in A)
            {
                Console.Write(el + " ");
            }

            Console.Write("\nЭлементы множества B: ");
            string[] strB = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            Console.Write("Готовое множество B: ");
            Hash(strB, B);
            B.IntersectWith(U);
            foreach (string el in B)
            {
                Console.Write(el + " ");
            }
            Array.Resize(ref strA, U.Count);
            Array.Resize(ref strB, U.Count);

            BitArray bitU = new BitArray(U.Count);
            BitArray bitA = new BitArray(strA.Length);
            BitArray bitB = new BitArray(strB.Length);


            update(bitU, bitA, U, strA);
            update(bitU, bitB, U, strB);

            BitArray total = LogicalOperations.Or(LogicalOperations.Or(LogicalOperations.Not(bitA), LogicalOperations.And(bitB, bitA)), LogicalOperations.Or(LogicalOperations.And(bitB, LogicalOperations.Not(bitA)), LogicalOperations.Not(bitB)));
            writeString(total, U);


        }
        public static void getThird()
        {
            HashSet<string> U = new HashSet<string>();
            HashSet<string> A = new HashSet<string>();
            HashSet<string> B = new HashSet<string>();
            HashSet<string> C = new HashSet<string>();

            Console.Write("Элементы множества U: ");
            string[] strU = Console.ReadLine().Split(new char[] { ' ', '\n', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries);
            Console.Write("Элементы множества U без повторений: ");
            Hash(strU, U);

            foreach (string el in U)
            {
                Console.Write(el + " ");
            }

            Console.Write("\nЭлементы множества A: ");
            string[] strA = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            Console.Write("Готовое множество A: ");
            Hash(strA, A);
            A.IntersectWith(U);
            foreach (string el in A)
            {
                Console.Write(el + " ");
            }

            Console.Write("\nЭлементы множества B: ");
            string[] strB = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            Console.Write("Готовое множество B: ");
            Hash(strB, B);
            B.IntersectWith(U);
            foreach (string el in B)
            {
                Console.Write(el + " ");
            }
            Console.Write("\nЭлементы множества C: ");
            string[] strC = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            Console.Write("Готовое множество C: ");
            Hash(strC, C);
            C.IntersectWith(U);
            foreach (string el in C)
            {
                Console.Write(el + " ");
            }
            Array.Resize(ref strA, U.Count);
            Array.Resize(ref strB, U.Count);
            Array.Resize(ref strC, U.Count);

            BitArray bitU = new BitArray(U.Count);
            BitArray bitA = new BitArray(strA.Length);
            BitArray bitB = new BitArray(strB.Length);
            BitArray bitC = new BitArray(strC.Length);

            update(bitU, bitA, U, strA);
            update(bitU, bitB, U, strB);
            update(bitU, bitC, U, strC);

           //BitArray Result = And(Or(Or(Not(bitA),bitB),Or(bitC,bitB)), Not(Or(bitA, bitB)));
            BitArray R = LogicalOperations.Not(LogicalOperations.Or(bitA, bitB));
             writeString(R, U);
            Console.ReadKey();
        }


       
    }

}

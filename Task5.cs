using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LZ_Day2_1
{
    public class Task5 : Task
    {
        public int rnd()
        {
            Random random = new Random();
            return random.Next(0, 3);// (-100, 100);
        }
        public int[,] fillRandom(int[,] array)
        {
            for (int i = 0; i < 5; i++)
            {
                Console.Write("|  ");
                for (int j = 0; j < 5; j++)
                {
                    array[i, j] = rnd();
                    Console.Write(array[i, j] + "\t|  ");
                }
                Console.WriteLine();
            }
            return array;
        }
        public int sum(List<int> arr, int from, int to)
        {
            int result = 0;
            for (int i = from + 1; i < to; i++)
                result += arr[i];
            return result;
        }
        public override void Go()
        {
        Start: Console.Clear();
            Console.WriteLine("Task5");
            Console.WriteLine("Дан двумерный массив размерностью 5х5,\n" +
                "заполненный случайными числами из диапазона от -100 до 100 ***.\n" +
                "Определить сумму элементов массива, расположенных между минимальным и максимальным элементами***.\n" +
                "(МАКСИМАЛЬНО УДАЛЕННЫМИ друг от друга)\n");
            int[,] array = new int[5, 5];
            List<int> arr = new List<int>();
            fillRandom(array);
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    arr.Add(array[i, j]);
                }
            }
            Console.WriteLine();
            Console.Write("| index |");
            for (int i = 0; i < 25; i++)
                Console.Write("  " + i + "\t|");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("| value |");
            foreach (int el in arr)
                Console.Write("  " + el + "\t|");
            Console.ResetColor();
            Console.WriteLine();
            int minElement = arr.Min();
            int maxElement = arr.Max();
            int LeftIndexMIN = arr.IndexOf(minElement);
            int RightIndexMIN = arr.LastIndexOf(minElement);
            int LeftIndexMAX = arr.IndexOf(maxElement);
            int RightIndexMAX = arr.LastIndexOf(maxElement);
            Console.WriteLine();
            Console.WriteLine("minElement = " + minElement +
                "\nIndex left - right: " + LeftIndexMIN + " - " + RightIndexMIN);
            Console.WriteLine("maxElelement = " + maxElement +
                "\nIndex left - right: " + LeftIndexMAX + " - " + RightIndexMAX);
            Console.WriteLine();
            List<int> result = new List<int>();
            int maxDistance;
            int maxDistanceTemp;
            Console.ForegroundColor = ConsoleColor.Magenta;
            if (LeftIndexMIN < LeftIndexMAX)
            {
                maxDistance = RightIndexMAX - LeftIndexMIN;
                result.Add(sum(arr, LeftIndexMIN, RightIndexMAX));
                if (RightIndexMAX < RightIndexMIN)
                {
                    maxDistanceTemp = RightIndexMIN - LeftIndexMAX;
                    if (maxDistanceTemp > maxDistance)
                        result[0] = sum(arr, LeftIndexMAX, RightIndexMIN);
                    else if (maxDistanceTemp == maxDistance)
                    {
                        result.Add(sum(arr, LeftIndexMAX, RightIndexMIN));
                        Console.Write("  ПОЛУЧАЕМ ДВЕ");
                    }
                }
            }
            else //(maxLeftIndex < minLeftIndex)
            {
                maxDistance = RightIndexMIN - LeftIndexMAX;
                result.Add(sum(arr, LeftIndexMAX, RightIndexMIN));
                if (RightIndexMIN < RightIndexMAX)
                {
                    maxDistanceTemp = RightIndexMAX - LeftIndexMIN;
                    if (maxDistanceTemp > maxDistance)
                        result[0] = sum(arr, LeftIndexMIN, RightIndexMAX);
                    else if (maxDistanceTemp == maxDistance)
                    {
                        result.Add(sum(arr, LeftIndexMIN, RightIndexMAX));
                        Console.Write("  ПОЛУЧАЕМ ДВЕ");
                    }
                }
            }
            Console.WriteLine("  Cумма(-Ы) элементов массива," +
                            " расположенных между минимальным и максимальным элементами\n" +
                            " (МАКСИМАЛЬНО УДАЛЕННЫМИ друг от друга):");
            Console.WriteLine();
            foreach (int sum in result)
                Console.WriteLine("\tСУММА = " + sum);
            Console.ResetColor();
            Console.WriteLine("\nВЫХОД  - ESK -\n");
            if (Console.ReadKey().Key != ConsoleKey.Escape)
                goto Start;
        }
    }
}

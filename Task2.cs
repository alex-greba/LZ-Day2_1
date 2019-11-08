using System;
using System.Collections.Generic;
using System.Text;

namespace LZ_Day2_1
{
    public class Task2 : Task
    {
        public int rnd()
        {
            Random random = new Random();
            return random.Next(0, 9);
        }
        public string[] fillRandom(string[] array)
        {
            int length = array.Length;
            for (int i = 0; i < length; i++)
            {
                array[i] = rnd().ToString();
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
            return array;
        }
        public override void Go()
        {
        Start: Console.Clear();
            Console.WriteLine("Task2");
            Console.WriteLine("Даны 2 массива размерности M и N соответственно.\n" +
                "Необходимо переписать в третий массив общие элементы первых двух массивов без повторений.");
            int M = 5, N = 5;
            string[] m = new string[M];
            string[] n = new string[N];
            fillRandom(m);
            fillRandom(n);
            List<string> commonElements = new List<string>();
            for (int i = 0; i < M; i++)
            {
                foreach (string nn in n)
                    if (nn == m[i] && commonElements.Find(el => el == nn) != nn)//жесть какая-то
                    { 
                        commonElements.Add(m[i]);
                    }
            }
            string[] final = commonElements.ToArray();
            Console.WriteLine("Result: ");
            foreach (string x in final)
                Console.Write(x + " ") ;
            Console.WriteLine("\nВЫХОД  - ESK -\n");
            if (Console.ReadKey().Key != ConsoleKey.Escape)
                goto Start;
        }
    }
}

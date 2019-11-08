using System;
using System.Collections.Generic;
using System.Text;

namespace LZ_Day2_1
{
    public class Task3 : Task
    {
        public override void Go()
        {
        Start: Console.Clear();
            Console.WriteLine("Task3");
            Console.WriteLine("Пользователь вводит строку. Проверить, является ли эта строка палиндромом.\n" +
                "Введите строку: ");
            string str = Console.ReadLine();
            char[] c = str.ToCharArray();
            int l = c.Length;
            bool palindrome = true;
            for (int i = 0; i < l / 2; i++)
            {
                if (c[i] != c[l - 1 - i])
                {
                    Console.WriteLine("\tПалиндромом не является...");
                    palindrome = false;
                    break;
                }
            }
            if (palindrome == true)
                Console.WriteLine("\tЭто Палиндромом...");
            Console.WriteLine("\nВЫХОД  - ESK -\n");
            if (Console.ReadKey().Key != ConsoleKey.Escape)
                goto Start;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace LZ_Day2_1
{
    public class Task4 : Task
    {
        public override void Go()
        {
        Start: Console.Clear();
            Console.WriteLine("Task4");
            Console.WriteLine("Введите предложение (для подсчета количества слов)..");
            ConsoleKeyInfo nextSymbol;
            string input = null;
            int count = 0;
            bool word = false;
            do
            {
                nextSymbol = Console.ReadKey();
                input += nextSymbol.KeyChar;
                if (nextSymbol.KeyChar == ' ' || nextSymbol.KeyChar == ',' || nextSymbol.KeyChar == ':' ||
                    nextSymbol.KeyChar == ';' || nextSymbol.KeyChar == '(' || nextSymbol.KeyChar == ')' ||
                    nextSymbol.KeyChar == '.' || nextSymbol.KeyChar == '!' || nextSymbol.Key == ConsoleKey.Enter)
                {
                    if (word == true)
                    {
                        word = false;
                        count++;
                    }
                }
                else { word = true; }
            }
            while (nextSymbol.KeyChar != '.' && nextSymbol.KeyChar != '!' && nextSymbol.Key != ConsoleKey.Enter);
            Console.WriteLine("\n\nВ предложении: " + input + "\n\t" + count + " слов(-а, -о)");
            Console.WriteLine("\nВЫХОД  - ESK -\n");
            if (Console.ReadKey().Key != ConsoleKey.Escape)
                goto Start;
        }
    }
}

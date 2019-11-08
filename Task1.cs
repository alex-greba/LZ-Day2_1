using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LZ_Day2_1
{
    public class Task1 : Task
    {
        public int Enter()
        {
            do
            {
                if (int.TryParse(Console.ReadLine(), out int correctly))
                    return correctly;
                else
                {
                    Console.WriteLine("Некорректно. Другое значение: ");
                }
            } while (true);
        }
        public double rnd()
        {
            Random random = new Random();
            return random.Next(-10, 10) + random.NextDouble();
        }


        public override void Go()
        {
        Start: Console.Clear();
            Console.WriteLine("Task1");
            Console.WriteLine("Объявить одномерный (5 элементов ) массив с именем A и двумерный\n" +
                "массив (3 строки, 4 столбца) дробных чисел с именем B.\n" +
                "Заполнитe одномерный массив А числами, введенными с клавиатуры пользователем:");
            int[] A = new int[5];
            double[,] B = new double[3, 4];

            decimal multiplicatoin = 1;
            long sumEven = 0;
            double sumOddColumn = 0;

            for (int i = 0; i < 5; i++)
            {
                A[i] = Enter();//2; 
                if (A[i] % 2 == 0)
                    sumEven += A[i];
                multiplicatoin *= A[i];
            }
            Console.WriteLine("\nМассив А: ");
            foreach (int a in A)
                Console.Write(a + " ");
            Console.WriteLine();

            double max = A.Max();
            double min = A.Min();
            double sum = A.Sum();
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 4; j++)
                {
                    B[i, j] = rnd();
                    multiplicatoin *= (decimal)B[i, j];
                    sum += B[i, j];
                    if (B[i, j] > max)
                        max = B[i, j];
                    else if (B[i, j] < min)
                        min = B[i, j];
                    if (j % 2 == 0)
                        sumOddColumn += B[i, j];
                }
            Console.WriteLine("\nМассив В: ");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                    Console.Write(B[i, j] + "\t|");
                Console.Write("\n");
            }
            Console.WriteLine("           Max = " + max +
                "\n           Min = " + min +
                "\n           Sum = " + sum +
                "\nMultiplicatoin = " + multiplicatoin +
                "\n       SumEven = " + sumEven +
                "\n  sumOddColumn = " + sumOddColumn);
            Console.WriteLine("\nВЫХОД  - ESK -\n");
            if (Console.ReadKey().Key != ConsoleKey.Escape)
                goto Start;
        }
    }
}

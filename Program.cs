using System;

namespace LZ_Day2_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("LZ Day2_1");
            Task[] task = new Task[5];
            task[0] = new Task1();
            task[1] = new Task2();
            task[2] = new Task3();
            task[3] = new Task4();
            task[4] = new Task5();
            //task[4].Go();
            foreach (Task t in task)
                t.Go();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncExample
{
    public class Ejemplo2
    {
        public static void Ejecutar()
        {
            var tarea1 = EjecutarTarea1Async();
            tarea1.Wait();

            var tarea2 = EjecutarTarea2Async();
            tarea2.Wait();
        }

        static async Task EjecutarTarea1Async()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            var subtarea1 = SubTarea1(1);
            await subtarea1;

            var subtarea2 = SubTarea2(1);
            await subtarea2;

            var subtarea3 = SubTarea3(1);
            await subtarea3;

            stopWatch.Stop();
            Console.WriteLine(stopWatch.Elapsed.TotalMilliseconds);
        }

        static async Task EjecutarTarea2Async()
        {
            var stopWatch = new Stopwatch();

            stopWatch.Start();

            var subtarea1 = SubTarea1(2);
            
            var subtarea2 = SubTarea2(2);
            
            var subtarea3 = SubTarea3(2);

            Task.WaitAll(subtarea1, subtarea2, subtarea3);

            stopWatch.Stop();
            Console.WriteLine(stopWatch.Elapsed.TotalMilliseconds);
        }

        static async Task SubTarea1(int tarea)
        {
            var amount = 0;
            var random = new Random();

            for (int i = 0; i < 100; i++)
            {
                amount = i * random.Next(1, 10);
            }

            Console.WriteLine($"Tarea: { tarea }. Subtarea 1. Monto { amount }.");
        }

        static async Task SubTarea2(int tarea)
        {
            var amount = 0;
            var random = new Random();

            for (int i = 0; i < 100; i++)
            {
                amount = i * random.Next(1, 10);
            }

            Console.WriteLine($"Tarea: { tarea }. Subtarea 2. Monto { amount }.");
        }

        static async Task SubTarea3(int tarea)
        {
            var amount = 0;
            var random = new Random();

            for (int i = 0; i < 100; i++)
            {
                amount = i * random.Next(1, 10);
            }

            Console.WriteLine($"Tarea: { tarea }. Subtarea 3. Monto { amount }.");
        }
    }
}

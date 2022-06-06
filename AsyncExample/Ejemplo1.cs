using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncExample
{
    public class Ejemplo1
    {
        public static void Ejecutar()
        {
            var tarea1 = new Task(EjecutarTarea);
            tarea1.Start();

            var tarea2 = new Task(EjecutarTarea);
            tarea2.Start();
        }

        static void EjecutarTarea()
        {
            var miThread = Thread.CurrentThread.ManagedThreadId;

            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine($"Thread: { miThread }. Iteración { i }.");
            }
        }
    }
}

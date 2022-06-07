using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClaseParallel
{
	internal class ForSecuencial
	{

		public static void IteracionSecuencial()
		{
			var sw = new Stopwatch();
			sw.Start();
			for (int i = 0; i < 200000; i++)
			{
				mostrarNumero(i);
			}
			sw.Stop();
			Console.WriteLine("El tiempo de ejecuccion fue de: " + sw.Elapsed.Seconds + "segundos");
			Console.ReadLine();

		}

		static void mostrarNumero(int aux)
		{

			Console.WriteLine($"Numero {aux}. Tarea realizada por el hilo {Thread.CurrentThread.ManagedThreadId}");

		}
	}
}

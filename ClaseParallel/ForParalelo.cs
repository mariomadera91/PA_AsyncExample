using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClaseParallel
{
	internal class ForParalelo
	{
		public static void IteracionParalela()
		{
			var sw = new Stopwatch();
			sw.Start();
			Parallel.For(0, 200000, mostrarNumero);
			sw.Stop();
			Console.WriteLine("El tiempo de ejecuccion fue de: " + sw.Elapsed.Seconds + "segundos");
			Console.ReadLine();
		}

		static void mostrarNumero(int aux)
		{
			Console.WriteLine($"Numero: {aux}. Tarea realizada por el hilo {Thread.CurrentThread.ManagedThreadId}");
		}
	}

}

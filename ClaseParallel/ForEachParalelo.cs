using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClaseParallel
{
	internal class ForEachParalelo
	{

		public static void IteracionParelela()
		{
			IEnumerable<int> lista = Enumerable.Range(1, 10);
			var sw = new Stopwatch();
			sw.Start();
			Parallel.ForEach(lista, aux =>
			{
				Console.WriteLine($"Numero: {aux}. Tarea realizada por el hilo {Thread.CurrentThread.ManagedThreadId}");
				Thread.Sleep(1000);

			});
			sw.Stop();
			Console.WriteLine("El tiempo de ejecuccion fue de: " + sw.Elapsed.Seconds + "segundos");
			Console.ReadLine();
		}
	}
}

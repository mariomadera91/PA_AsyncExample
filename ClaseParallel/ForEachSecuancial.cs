using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClaseParallel
{
	internal class ForEachSecuencial
	{

		public static void IteracionSecuncial()
		{
			IEnumerable<int> lista = Enumerable.Range(1, 10);
			var sw = new Stopwatch();
			sw.Start();
			foreach (var aux in lista)
			{
				Console.WriteLine($"Numero: {aux}. Tarea realizada por el hilo {Thread.CurrentThread.ManagedThreadId}");
				Thread.Sleep(1000);

			}
			sw.Stop();
			Console.WriteLine("El tiempo de ejecuccion fue de: " + sw.Elapsed.Seconds + "segundos");
			Console.ReadLine();
		}

	}
}

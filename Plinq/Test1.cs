using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plinq
{
	internal class Test1
	{

		private static IEnumerable<int> _numbers;

		public static void Iterate()
		{

			_numbers = Enumerable.Range(0, 1000000000);

			var watch = new Stopwatch();
			watch.Start();


			var parallelTask = Task.Run(() => ParallelTask());
			parallelTask.Wait();


			watch.Stop();

			Console.WriteLine($"Paralelamente tardo: {watch.Elapsed.Seconds} segundos");


			watch.Reset();
			watch.Start();

			var sequentialTask = Task.Run(() => SequentialTask());
			sequentialTask.Wait();


			watch.Stop();

			Console.WriteLine($"Secuancialmente tardo: {watch.Elapsed.Seconds} segundos");

			Console.ReadKey();
		}

		private static void ParallelTask()
		{
			_numbers
				.AsParallel()
				.Select(x => DoWork(x))
				.ToArray();
		}

		private static void SequentialTask()
		{
			_numbers
				.Select(x => DoWork(x))
				.ToArray();
		}

		private static int DoWork(int aux)
		{
			return aux * 10;
		}

	}
}

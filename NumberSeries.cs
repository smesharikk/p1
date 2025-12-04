using System;
using кр_1_попытка2;

class Program
{
	static void Main()
	{
		INumberSeries fib = new FibonacciSeries();
		INumberSeries euler = new EulerSeries();

		int N = 10;

		Console.WriteLine("Первые 10 чисел ряда Фибоначчи:");
		fib.Iterate(N, x => Console.Write(x + " "));

		Console.WriteLine("\n\nПервые 10 чисел ряда Эйлера:");
		euler.Iterate(N, x => Console.Write(x + " "));

		Console.WriteLine("\n\nОтрицательный ряд Фибоначчи:");
		INumberSeries negFib = new NegativeSeries(fib);
		negFib.Iterate(N, x => Console.Write(x + " "));

		Console.WriteLine("\n\nОтрицательный ряд Эйлера:");
		INumberSeries negEuler = new NegativeSeries(euler);
		negEuler.Iterate(N, x => Console.Write(x + " "));

		Console.WriteLine();
	}
}

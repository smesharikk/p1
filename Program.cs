using кр_подготовка1;

class Program
{
	static void Main()
	{
		INumberSeries fibonacci = new FibonacciSeries();
		INumberSeries euler = new EulerSeries();

		INumberSeries negativeFibonacci = new NegativeSeries(fibonacci);
		INumberSeries negativeEuler = new NegativeSeries(euler);

		int N = 10;

		Console.WriteLine("Первые 10 чисел ряда Фибоначчи:");
		fibonacci.Iterate(N, x => Console.Write(x + " "));

		Console.WriteLine("\n\nПервые 10 чисел ряда Эйлера:");
		euler.Iterate(N, x => Console.Write(x + " "));

		Console.WriteLine("\n\nОТРИЦАТЕЛЬНЫЙ ряд Фибоначчи:");
		negativeFibonacci.Iterate(N, x => Console.Write(x + " "));

		Console.WriteLine("\n\nОТРИЦАТЕЛЬНЫЙ ряд Эйлера:");
		negativeEuler.Iterate(N, x => Console.Write(x + " "));

		Console.WriteLine();
	}
}

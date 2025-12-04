using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace кр_подготовка1
{
	using System;

	public interface INumberSeries
	{
		int GetFirst();
		int GetSecond();
		int GetNext(int current, int previous);

		// Внутренний итератор
		void Iterate(int n, Action<int> action);
	}

	// ---------------- РЯД ФИБОНАЧЧИ ----------------

	public class FibonacciSeries : INumberSeries
	{
		public int GetFirst() => 0;
		public int GetSecond() => 1;

		public int GetNext(int current, int previous)
		{
			return current + previous;
		}

		public void Iterate(int n, Action<int> action)
		{
			int prev = GetFirst();
			int curr = GetSecond();

			if (n >= 1) action(prev);
			if (n >= 2) action(curr);

			for (int i = 3; i <= n; i++)
			{
				int next = GetNext(curr, prev);
				action(next);

				prev = curr;
				curr = next;
			}
		}
	}

	// ---------------- РЯД ЭЙЛЕРА ----------------

	public class EulerSeries : INumberSeries
	{
		public int GetFirst() => 1;
		public int GetSecond() => 1;

		public int GetNext(int current, int previous)
		{
			return current + previous + 1;
		}

		public void Iterate(int n, Action<int> action)
		{
			int prev = GetFirst();
			int curr = GetSecond();

			if (n >= 1) action(prev);
			if (n >= 2) action(curr);

			for (int i = 3; i <= n; i++)
			{
				int next = GetNext(curr, prev);
				action(next);

				prev = curr;
				curr = next;
			}
		}
	}

	// ---------------- ДЕКОРАТОР ОТРИЦАТЕЛЬНОГО РЯДА ----------------

	public class NegativeSeries : INumberSeries
	{
		private readonly INumberSeries series;

		public NegativeSeries(INumberSeries series)
		{
			this.series = series;
		}

		public int GetFirst() => -series.GetFirst();

		public int GetSecond() => -series.GetSecond();

		public int GetNext(int current, int previous)
		{
			// current и previous уже отрицательные, поэтому их знак меняем обратно
			int next = series.GetNext(-current, -previous);
			return -next;
		}

		public void Iterate(int n, Action<int> action)
		{
			int prev = GetFirst();
			int curr = GetSecond();

			if (n >= 1) action(prev);
			if (n >= 2) action(curr);

			for (int i = 3; i <= n; i++)
			{
				int next = GetNext(curr, prev);
				action(next);

				prev = curr;
				curr = next;
			}
		}
	}

}

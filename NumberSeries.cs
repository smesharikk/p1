using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace кр_1_попытка2
{
	public interface INumberSeries
	{
		int GetFirst();
		int GetSecond();
		int GetNext(int current, int previous);

		void Iterate(int n, Action<int> action); // внутренний итератор
	}

	

	public abstract class NumberSeriesBase : INumberSeries
	{
		public abstract int GetFirst();
		public abstract int GetSecond();
		public abstract int GetNext(int current, int previous);


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

	// ---------------- РЯД ФИБОНАЧЧИ ----------------

	public class FibonacciSeries : NumberSeriesBase
	{
		public override int GetFirst() => 0;
		public override int GetSecond() => 1;

		public override int GetNext(int current, int previous)
		{
			return current + previous;
		}
	}

	// ---------------- РЯД ЭЙЛЕРА ----------------

	public class EulerSeries : NumberSeriesBase
	{
		public override int GetFirst() => 1;
		public override int GetSecond() => 1;

		public override int GetNext(int current, int previous)
		{
			return current + previous + 1;
		}
	}

	// ---------------- ДЕКОРАТОР ОТРИЦАТЕЛЬНОГО РЯДА ----------------

	public class NegativeSeries : NumberSeriesBase
	{
		private readonly INumberSeries series;

		public NegativeSeries(INumberSeries series)
		{
			this.series = series;
		}

		public override int GetFirst() => -series.GetFirst();

		public override int GetSecond() => -series.GetSecond();

		public override int GetNext(int current, int previous)
		{
		
			int originalNext = series.GetNext(-current, -previous);
			return -originalNext;
		}
	}
}

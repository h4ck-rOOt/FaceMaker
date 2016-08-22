using System;

namespace RC.Common
{
	public class Triplet<TFirst, TSecond, TThird>
	{
		public TFirst First
		{
			get;
			set;
		}

		public TSecond Second
		{
			get;
			set;
		}

		public TThird Third
		{
			get;
			set;
		}

		public Triplet()
		{
		}

		public Triplet(TFirst first, TSecond second, TThird third)
		{
			this.First = first;
			this.Second = second;
			this.Third = third;
		}
	}
}

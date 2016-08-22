using System;

namespace RC.Common
{
	public class Pair<TFirst, TSecond>
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

		public Pair()
		{
		}

		public Pair(TFirst first, TSecond second)
		{
			this.First = first;
			this.Second = second;
		}
	}
}

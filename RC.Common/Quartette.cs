using System;

namespace RC.Common
{
	public class Quartette<TFirst, TSecond, TThird, TFourth>
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

		public TFourth Fourth
		{
			get;
			set;
		}

		public Quartette()
		{
		}

		public Quartette(TFirst first, TSecond second, TThird third, TFourth fourth)
		{
			this.First = first;
			this.Second = second;
			this.Third = third;
			this.Fourth = fourth;
		}
	}
}

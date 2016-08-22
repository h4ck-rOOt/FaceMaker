using System;

namespace FaceMaker.Data
{
	public static class Const
	{
		public static class ImageOutputSize
		{
			public static readonly int Width = 192;

			public static readonly int Height = 192;
		}

		public static class ImageSize
		{
			public static readonly int Width = 230;

			public static readonly int Height = 230;
		}

		public static string partsDir = "picture";

		public static int MaxSaveSize = 400;

		public static int MinSaveSize = 1;

		public static int MaxValue = 100;

		public static int MinValue = -100;
	}
}

using System;

namespace FaceMaker.Data
{
	public class ColorStruct
	{
		public int Red
		{
			get;
			set;
		}

		public int Green
		{
			get;
			set;
		}

		public int Blue
		{
			get;
			set;
		}

		public int Brightness
		{
			get;
			set;
		}

		public int Contrast
		{
			get;
			set;
		}

		public ColorStruct()
		{
			this.Red = 0;
			this.Green = 0;
			this.Blue = 0;
			this.Brightness = 0;
			this.Contrast = 0;
		}
	}
}

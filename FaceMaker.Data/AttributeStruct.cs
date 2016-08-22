using System;

namespace FaceMaker.Data
{
	public class AttributeStruct
	{
		public class PositionStruct
		{
			public int X
			{
				get;
				set;
			}

			public int Y
			{
				get;
				set;
			}

			public int Direction
			{
				get;
				set;
			}

			public PositionStruct()
			{
				this.X = (Const.ImageOutputSize.Width - Const.ImageSize.Width) / 2;
				this.Y = (Const.ImageOutputSize.Height - Const.ImageSize.Height) / 2;
				this.Direction = 0;
			}
		}

		public PositionStruct Position
		{
			get;
			set;
		}

		public ColorStruct Color
		{
			get;
			set;
		}

		public AttributeStruct()
		{
			this.Position = new PositionStruct();
			this.Color = new ColorStruct();
		}
	}
}
